$wpfDir = "E:\desk1\NarakaBladepoint-WPF\NarakaBladepoint.Modules"
$avDir = "E:\desk1\NarakaBladepoint-Avalonia\NarakaBladepoint.Modules"
$utf8 = New-Object System.Text.UTF8Encoding $true

# Event name mapping WPF -> Avalonia
$eventMap = @{
    'MouseLeftButtonDown' = 'PointerPressed'
    'MouseLeftButtonUp' = 'PointerReleased'
    'MouseRightButtonDown' = 'PointerPressed'
    'Checked' = 'IsCheckedChanged'
    'Unchecked' = 'IsCheckedChanged'
    'IsSelectedChanged' = 'SelectionChanged'
    'TextChanged' = 'TextChanged'
}

# Find WPF files with b:Interaction.Triggers
$wpfFiles = Get-ChildItem $wpfDir -Recurse -Filter "*.xaml" | Where-Object {
    $_.FullName -notmatch "\\bin\\|\\obj\\"
} | Where-Object {
    $c = [System.IO.File]::ReadAllText($_.FullName, $utf8)
    $c -match 'b:Interaction\.Triggers'
}

$totalBlocks = 0
$totalFiles = 0
$warnings = @()

foreach ($wpfFile in $wpfFiles) {
    $rel = $wpfFile.FullName.Replace($wpfDir + "\", "")
    $avRel = $rel -replace "\.xaml$", ".axaml"
    $avPath = Join-Path $avDir $avRel
    
    if (-not (Test-Path $avPath)) {
        $warnings += "SKIP: No Avalonia file for $rel"
        continue
    }
    
    $wpfLines = [System.IO.File]::ReadAllLines($wpfFile.FullName, $utf8)
    $avContent = [System.IO.File]::ReadAllText($avPath, $utf8)
    $avLines = New-Object System.Collections.ArrayList
    foreach ($line in ($avContent -split "`n")) { [void]$avLines.Add($line) }
    
    $fileModified = $false
    $blocksInFile = 0
    
    # Step 1: Add namespace declarations if needed
    $needsNsI = $avContent -notmatch 'xmlns:i='
    $needsNsIa = $avContent -notmatch 'xmlns:ia='
    
    if ($needsNsI -or $needsNsIa) {
        # Find the line with mc:Ignorable or the last xmlns line
        for ($n = 0; $n -lt $avLines.Count; $n++) {
            if ($avLines[$n] -match 'mc:Ignorable=') {
                # Insert before mc:Ignorable
                $indent = ""
                if ($avLines[$n] -match '^(\s+)') { $indent = $Matches[1] }
                $insertLines = @()
                if ($needsNsI) { $insertLines += "${indent}xmlns:i=`"using:Avalonia.Xaml.Interactivity`"" }
                if ($needsNsIa) { $insertLines += "${indent}xmlns:ia=`"using:Avalonia.Xaml.Interactions.Core`"" }
                $insertText = ($insertLines -join "`n") + "`n"
                $currentLine = $avLines[$n]
                $avLines[$n] = $insertText + $currentLine
                $fileModified = $true
                break
            }
        }
    }
    
    # Remove old xmlns:b if present
    $avText = ($avLines -join "`n")
    if ($avText -match 'xmlns:b="http://schemas\.microsoft\.com/xaml/behaviors"\s*\n?') {
        $avText = $avText -replace '\s*xmlns:b="http://schemas\.microsoft\.com/xaml/behaviors"\s*\n', "`n"
        $fileModified = $true
    }
    # Remove xmlns:core if present
    if ($avText -match 'xmlns:core=') {
        $avText = $avText -replace '\s*xmlns:core="[^"]*"\s*\n', "`n"
        $fileModified = $true
    }
    
    # Re-split after namespace changes
    $avLines = New-Object System.Collections.ArrayList
    foreach ($line in ($avText -split "`n")) { [void]$avLines.Add($line) }
    
    # Step 2: Extract trigger blocks from WPF
    $blocks = @()
    $i = 0
    while ($i -lt $wpfLines.Count) {
        if ($wpfLines[$i] -match '^\s*<b:Interaction\.Triggers>') {
            $trigStart = $i
            $depth = 1
            $i++
            while ($i -lt $wpfLines.Count -and $depth -gt 0) {
                if ($wpfLines[$i] -match '^\s*<b:Interaction\.Triggers') { $depth++ }
                if ($wpfLines[$i] -match '</b:Interaction\.Triggers>') { $depth-- }
                $i++
            }
            $trigEnd = $i - 1
            
            # Get trigger content
            $trigContent = $wpfLines[$trigStart..$trigEnd]
            
            # Find anchor: walk backward to find the line ending with >
            $anchorIdx = $trigStart - 1
            while ($anchorIdx -ge 0 -and $wpfLines[$anchorIdx].Trim() -eq '') { $anchorIdx-- }
            
            # Collect multi-line parent opening tag
            $parentEndIdx = $anchorIdx
            $parentStartIdx = $anchorIdx
            # Walk back to find the opening < of parent element
            $tempText = $wpfLines[$parentStartIdx]
            while ($parentStartIdx -gt 0 -and $tempText -notmatch '<\w') {
                $parentStartIdx--
                $tempText = $wpfLines[$parentStartIdx]
            }
            
            $parentTag = ""
            if ($tempText -match '<([\w:]+)') { $parentTag = $Matches[1] }
            
            # Get x:Name if present
            $parentBlock = ($wpfLines[$parentStartIdx..$parentEndIdx] -join " ")
            $xName = ""
            if ($parentBlock -match 'x:Name="([^"]+)"') { $xName = $Matches[1] }
            if (-not $xName -and $parentBlock -match '\bName="([^"]+)"') { $xName = $Matches[1] }
            
            # Get the anchor line text and clean it for matching
            $anchorText = $wpfLines[$parentEndIdx].Trim()
            
            # Also get 2 lines before for context
            $ctx1 = ""
            $ctx2 = ""
            $ctxIdx = $parentEndIdx - 1
            while ($ctxIdx -ge 0 -and $wpfLines[$ctxIdx].Trim() -eq '') { $ctxIdx-- }
            if ($ctxIdx -ge 0) { $ctx1 = $wpfLines[$ctxIdx].Trim() }
            $ctxIdx--
            while ($ctxIdx -ge 0 -and $wpfLines[$ctxIdx].Trim() -eq '') { $ctxIdx-- }
            if ($ctxIdx -ge 0) { $ctx2 = $wpfLines[$ctxIdx].Trim() }
            
            # Get the line after the trigger block
            $afterIdx = $trigEnd + 1
            while ($afterIdx -lt $wpfLines.Count -and $wpfLines[$afterIdx].Trim() -eq '') { $afterIdx++ }
            $afterText = if ($afterIdx -lt $wpfLines.Count) { $wpfLines[$afterIdx].Trim() } else { "" }
            
            $blocks += @{
                TrigContent = $trigContent
                AnchorText = $anchorText
                AfterText = $afterText
                Ctx1 = $ctx1
                Ctx2 = $ctx2
                ParentTag = $parentTag
                XName = $xName
                TrigStart = $trigStart
            }
        } else {
            $i++
        }
    }
    
    # Step 3: For each trigger block, find insertion point in Avalonia and insert
    $avSearchStart = 0
    $insertionOffset = 0 # tracks line count changes from previous insertions
    
    foreach ($block in $blocks) {
        # Convert trigger content to Avalonia syntax
        $converted = @()
        foreach ($line in $block.TrigContent) {
            $newLine = $line
            $newLine = $newLine -replace '<b:Interaction\.Triggers>', '<i:Interaction.Behaviors>'
            $newLine = $newLine -replace '</b:Interaction\.Triggers>', '</i:Interaction.Behaviors>'
            
            # EventTrigger -> EventTriggerBehavior with event mapping
            if ($newLine -match '<b:EventTrigger\s+EventName="(\w+)"') {
                $wpfEvent = $Matches[1]
                $avEvent = if ($eventMap.ContainsKey($wpfEvent)) { $eventMap[$wpfEvent] } else { $wpfEvent }
                $newLine = $newLine -replace '<b:EventTrigger\s+EventName="\w+">', "<ia:EventTriggerBehavior EventName=`"$avEvent`">"
                $newLine = $newLine -replace '<b:EventTrigger\s+EventName="\w+"\s*/>', "<ia:EventTriggerBehavior EventName=`"$avEvent`" />"
            }
            $newLine = $newLine -replace '</b:EventTrigger>', '</ia:EventTriggerBehavior>'
            
            # InvokeCommandAction
            $newLine = $newLine -replace '<b:InvokeCommandAction\b', '<ia:InvokeCommandAction'
            $newLine = $newLine -replace '</b:InvokeCommandAction>', '</ia:InvokeCommandAction>'
            
            # core:DataTrigger -> ia:DataTriggerBehavior
            if ($newLine -match '<core:DataTrigger\s+Binding="([^"]+)"\s+Value="([^"]+)"') {
                $binding = $Matches[1]
                $value = $Matches[2]
                $newLine = $newLine -replace '<core:DataTrigger\s+Binding="[^"]+"\s+Value="[^"]+">', "<ia:DataTriggerBehavior Binding=`"$binding`" ComparisonCondition=`"Equal`" Value=`"$value`">"
            }
            $newLine = $newLine -replace '</core:DataTrigger>', '</ia:DataTriggerBehavior>'
            
            # core:ChangePropertyAction -> ia:ChangePropertyAction
            $newLine = $newLine -replace '<core:ChangePropertyAction\b', '<ia:ChangePropertyAction'
            $newLine = $newLine -replace '</core:ChangePropertyAction>', '</ia:ChangePropertyAction>'
            
            # Fix RelativeSource AncestorType -> Avalonia $parent syntax
            if ($newLine -match 'RelativeSource=\{RelativeSource\s+(Mode=FindAncestor,\s*)?AncestorType=\{?x:Type\s+(\w+:?\w+)\}?\}') {
                $ancestorType = $Matches[2]
                $newLine = $newLine -replace 'TargetObject="\{Binding\s+RelativeSource=\{RelativeSource[^}]*\},\s*Path=([^"]+)\}"', "TargetObject=`"{Binding `$parent[$ancestorType].`$1}`""
            }
            
            # Fix ElementName= for Avalonia (ElementName=xxx -> #xxx)
            if ($newLine -match 'CommandParameter="\{Binding\s+ElementName=(\w+),\s*Path=([^}]+)\}"') {
                $elemName = $Matches[1]
                $propPath = $Matches[2]
                $newLine = $newLine -replace 'CommandParameter="\{Binding\s+ElementName=\w+,\s*Path=[^}]+\}"', "CommandParameter=`"{Binding #$elemName.$propPath}`""
            }
            
            $converted += $newLine
        }
        
        # Find insertion point in Avalonia
        # Strategy: search for the anchor line (possibly modified) in Avalonia
        $anchorClean = $block.AnchorText
        # Remove d: attributes
        $anchorClean = $anchorClean -replace '\s*d:\w+="[^"]*"', ''
        # Remove Style references (they may have been removed if style files are empty)  
        # Don't remove Style by default - only if no match found
        $anchorClean = $anchorClean.Trim()
        
        $found = $false
        $insertAt = -1
        
        # First pass: exact match on cleaned anchor
        for ($k = $avSearchStart; $k -lt $avLines.Count; $k++) {
            $avLine = $avLines[$k].TrimEnd()
            $avLineTrimmed = $avLine.Trim()
            if ($avLineTrimmed -eq $anchorClean) {
                $insertAt = $k
                $found = $true
                break
            }
        }
        
        # Second pass: try removing Style from anchor too
        if (-not $found) {
            $anchorNoStyle = $anchorClean -replace '\s*Style="\{StaticResource\s+[^}]+\}"', ''
            $anchorNoStyle = $anchorNoStyle.Trim()
            for ($k = $avSearchStart; $k -lt $avLines.Count; $k++) {
                $avLineTrimmed = $avLines[$k].Trim()
                if ($avLineTrimmed -eq $anchorNoStyle) {
                    $insertAt = $k
                    $found = $true
                    break
                }
            }
        }
        
        # Third pass: fuzzy match using context
        if (-not $found) {
            $ctx1Clean = $block.Ctx1 -replace '\s*d:\w+="[^"]*"', '' -replace '\s*Style="\{StaticResource\s+[^}]+\}"', ''
            $ctx1Clean = $ctx1Clean.Trim()
            if ($ctx1Clean.Length -gt 10) {
                for ($k = $avSearchStart; $k -lt $avLines.Count; $k++) {
                    if ($avLines[$k].Trim() -eq $ctx1Clean) {
                        # Check next non-empty line
                        $nextK = $k + 1
                        while ($nextK -lt $avLines.Count -and $avLines[$nextK].Trim() -eq '') { $nextK++ }
                        $nextLine = if ($nextK -lt $avLines.Count) { $avLines[$nextK].Trim() } else { "" }
                        
                        $afterClean = $block.AfterText -replace '\s*d:\w+="[^"]*"', ''
                        $afterClean = $afterClean.Trim()
                        
                        # The next line in Avalonia should be similar to the AfterText
                        # (since the trigger was removed, the after-trigger line comes right after the anchor)
                        if ($nextLine -eq $afterClean -or $nextLine.StartsWith("</")) {
                            $insertAt = $nextK - 1
                            $found = $true
                            break
                        }
                    }
                }
            }
        }
        
        # Fourth pass: match by x:Name
        if (-not $found -and $block.XName) {
            for ($k = $avSearchStart; $k -lt $avLines.Count; $k++) {
                if ($avLines[$k] -match "Name=`"$([regex]::Escape($block.XName))`"") {
                    # Found the element by name, now find where its opening tag closes
                    $tagK = $k
                    while ($tagK -lt $avLines.Count -and $avLines[$tagK] -notmatch '>\s*$') { $tagK++ }
                    $insertAt = $tagK
                    $found = $true
                    break
                }
            }
        }
        
        if (-not $found) {
            $warnings += "NOMATCH in $avRel (WPF line $($block.TrigStart)): anchor='$($block.AnchorText)'"
            continue
        }
        
        # Determine indentation
        $baseIndent = ""
        if ($avLines[$insertAt] -match '^(\s+)') { $baseIndent = $Matches[1] }
        $trigIndent = $baseIndent + "    "
        
        # Re-indent converted lines
        # First find the original indentation of the trigger block
        $origIndent = ""
        if ($block.TrigContent[0] -match '^(\s+)') { $origIndent = $Matches[1] }
        
        $reindented = @()
        foreach ($cLine in $converted) {
            if ($cLine.Trim() -eq '') {
                $reindented += ""
            } else {
                # Remove original indent, add new indent
                $stripped = $cLine
                if ($origIndent -and $stripped.StartsWith($origIndent)) {
                    $stripped = $stripped.Substring($origIndent.Length)
                } elseif ($stripped -match '^\s+') {
                    $stripped = $stripped.TrimStart()
                }
                $reindented += $trigIndent + $stripped
            }
        }
        
        # Insert the converted trigger lines after insertAt
        $insertIndex = $insertAt + 1
        for ($r = 0; $r -lt $reindented.Count; $r++) {
            $avLines.Insert($insertIndex + $r, $reindented[$r])
        }
        
        $avSearchStart = $insertIndex + $reindented.Count
        $blocksInFile++
        $totalBlocks++
        $fileModified = $true
    }
    
    if ($fileModified) {
        $finalContent = ($avLines -join "`n")
        [System.IO.File]::WriteAllText($avPath, $finalContent, $utf8)
        $totalFiles++
        Write-Output "FIXED: $avRel ($blocksInFile trigger blocks)"
    }
}

Write-Output ""
Write-Output "=== Summary ==="
Write-Output "Restored $totalBlocks trigger blocks in $totalFiles files"

if ($warnings.Count -gt 0) {
    Write-Output ""
    Write-Output "=== Warnings ($($warnings.Count)) ==="
    foreach ($w in $warnings) { Write-Output "  $w" }
}
