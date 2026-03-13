$avDir = "E:\desk1\NarakaBladepoint-Avalonia\NarakaBladepoint.Modules"
$wpfDir = "E:\desk1\NarakaBladepoint-WPF\NarakaBladepoint.Modules"
$utf8 = [System.Text.Encoding]::UTF8

$allAvFiles = Get-ChildItem $avDir -Recurse -Filter "*.axaml" | Where-Object {
    $_.FullName -notmatch "\\bin\\" -and $_.FullName -notmatch "\\obj\\"
}

$issues = @()

foreach ($avFile in $allAvFiles) {
    $rel = $avFile.FullName.Replace($avDir + "\", "")
    $wpfRel = $rel -replace "\.axaml$", ".xaml"
    $wpfPath = Join-Path $wpfDir $wpfRel
    
    if (-not (Test-Path $wpfPath)) { continue }
    
    $avContent = [System.IO.File]::ReadAllText($avFile.FullName, $utf8)
    $wpfContent = [System.IO.File]::ReadAllText($wpfPath, $utf8)
    
    # Count elements in WPF vs Avalonia to detect missing content
    $wpfElementCount = ([regex]::Matches($wpfContent, '<\w')).Count
    $avElementCount = ([regex]::Matches($avContent, '<\w')).Count
    
    $diff = $wpfElementCount - $avElementCount
    if ([Math]::Abs($diff) -gt 5) {
        $issues += "ELEMENT COUNT DIFF: $rel (WPF=$wpfElementCount, AV=$avElementCount, diff=$diff)"
    }
    
    # Check for WPF-only xmlns that shouldn't be in Avalonia
    if ($avContent -match 'xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"') {
        $issues += "WRONG XMLNS: $rel (still has WPF default namespace)"
    }
    
    # Check for WPF pack:// URIs
    if ($avContent -match 'pack://') {
        $issues += "PACK URI: $rel (still has pack:// URI)"
    }
    
    # Check for remaining d:DataContext or d:DesignInstance
    if ($avContent -match 'd:DataContext|d:DesignInstance|d:SampleData') {
        $issues += "DESIGN TIME: $rel (still has d:DataContext/DesignInstance/SampleData)"
    }
    
    # Check for WPF Visibility="Collapsed" etc (not ScrollBar)
    $visMatches = [regex]::Matches($avContent, '(?<![A-Za-z])Visibility="(Visible|Collapsed|Hidden)"')
    foreach ($m in $visMatches) {
        $line = $avContent.Substring(0, $m.Index).Split("`n").Count
        $lineText = ($avContent.Split("`n"))[$line - 1].Trim()
        if ($lineText -notmatch 'ScrollBar|GridLines|Headers') {
            $issues += "VISIBILITY: $rel line $line ($($m.Value))"
        }
    }
    
    # Check for ControlTemplate.Triggers or Style.Triggers
    if ($avContent -match 'ControlTemplate\.Triggers|Style\.Triggers') {
        $issues += "WPF TRIGGERS: $rel"
    }
    
    # Check for Mode=FindAncestor
    if ($avContent -match 'Mode=FindAncestor') {
        $issues += "FINDANCESTOR: $rel"
    }
    
    # Check for AncestorLevel
    if ($avContent -match 'AncestorLevel=') {
        $issues += "ANCESTORLEVEL: $rel"
    }
    
    # Check for unsupported d: attributes
    if ($avContent -match 'd:(?!DesignWidth|DesignHeight)\w+=') {
        $issues += "D:ATTR: $rel (has unsupported d: attributes)"
    }
    
    # Check for SnapsToDevicePixels
    if ($avContent -match 'SnapsToDevicePixels') {
        $issues += "SNAPS: $rel"
    }
    
    # Check for RecognizesAccessKey
    if ($avContent -match 'RecognizesAccessKey') {
        $issues += "RECOGNIZESACCESSKEY: $rel"
    }
    
    # Check for TextElement.
    if ($avContent -match 'TextElement\.') {
        $issues += "TEXTELEMENT: $rel"
    }
    
    # Check for missing Chinese that exists in WPF (garbled text detection)
    $gbk = [System.Text.Encoding]::GetEncoding("GBK")
    $chineseRegex = [regex]::new('[\u4E00-\u9FFF\u3400-\u4DBF\uFF01-\uFF5E\u3000-\u303F]+')
    $wpfChinese = $chineseRegex.Matches($wpfContent) | ForEach-Object { $_.Value } | Select-Object -Unique
    foreach ($cs in $wpfChinese) {
        $garbled = $gbk.GetString($utf8.GetBytes($cs))
        if ($garbled -ne $cs -and $avContent.Contains($garbled)) {
            $issues += "GARBLED: $rel ('$cs' still garbled)"
            break
        }
    }
}

if ($issues.Count -eq 0) {
    Write-Output "No issues found!"
} else {
    Write-Output "=== Found $($issues.Count) issues ==="
    foreach ($i in $issues) {
        Write-Output "  $i"
    }
}
