$avDir = "E:\desk1\NarakaBladepoint-Avalonia\NarakaBladepoint.Modules"
$wpfDir = "E:\desk1\NarakaBladepoint-WPF\NarakaBladepoint.Modules"
$utf8 = [System.Text.Encoding]::UTF8

# Known WPF-only patterns that are invalid in Avalonia
$wpfPatterns = @(
    @{ Name = "Visibility.Visible/Collapsed/Hidden"; Pattern = 'Visibility="(Visible|Collapsed|Hidden)"'; Note = "Avalonia uses IsVisible=true/false" },
    @{ Name = "Panel.ZIndex"; Pattern = 'Panel\.ZIndex='; Note = "Avalonia uses ZIndex directly" },
    @{ Name = "Margin with negative values on wrong type"; Pattern = ''; Note = "" },
    @{ Name = "HorizontalContentAlignment on wrong type"; Pattern = ''; Note = "" },
    @{ Name = "VerticalContentAlignment on wrong type"; Pattern = ''; Note = "" },
    @{ Name = "ActualWidth/ActualHeight"; Pattern = 'ActualWidth|ActualHeight'; Note = "Avalonia uses Bounds.Width/Height" },
    @{ Name = "StringFormat in Binding"; Pattern = 'StringFormat='; Note = "Check if valid in Avalonia context" },
    @{ Name = "UpdateSourceTrigger"; Pattern = 'UpdateSourceTrigger='; Note = "Not needed in Avalonia" },
    @{ Name = "x:Static"; Pattern = '\{x:Static '; Note = "Avalonia uses x:Static differently" },
    @{ Name = "pack:// URI"; Pattern = 'pack://'; Note = "Should be avares://" },
    @{ Name = "Interaction.Triggers (WPF)"; Pattern = 'xmlns:b="clr-namespace:Microsoft\.Xaml\.Behaviors;assembly=Microsoft\.Xaml\.Behaviors"'; Note = "Check if behaviors work" },
    @{ Name = "ControlTemplate.Triggers"; Pattern = 'ControlTemplate\.Triggers'; Note = "Not supported in Avalonia" },
    @{ Name = "Style.Triggers"; Pattern = 'Style\.Triggers'; Note = "Not supported in Avalonia" },
    @{ Name = "DataTrigger"; Pattern = '<core:DataTrigger\b'; Note = "WPF behavior, check compatibility" },
    @{ Name = "EventTrigger from Behaviors"; Pattern = '<b:EventTrigger\b'; Note = "Check Avalonia behavior compatibility" },
    @{ Name = "DesignInstance"; Pattern = 'd:DesignInstance'; Note = "Not supported in Avalonia" },
    @{ Name = "d:DataContext"; Pattern = 'd:DataContext'; Note = "Not supported in Avalonia" },
    @{ Name = "d:SampleData"; Pattern = 'd:SampleData'; Note = "Not supported in Avalonia" }
)

$allFiles = Get-ChildItem $avDir -Recurse -Filter "*.axaml" | Where-Object {
    $_.FullName -notmatch "\\bin\\" -and $_.FullName -notmatch "\\obj\\"
}

Write-Output "=== Scanning $($allFiles.Count) .axaml files for WPF-only patterns ==="
Write-Output ""

foreach ($p in $wpfPatterns) {
    if ([string]::IsNullOrEmpty($p.Pattern)) { continue }
    
    $matches = $allFiles | ForEach-Object {
        $content = [System.IO.File]::ReadAllText($_.FullName, $utf8)
        $regex = [regex]::new($p.Pattern)
        $found = $regex.Matches($content)
        if ($found.Count -gt 0) {
            $rel = $_.FullName.Replace($avDir + "\", "")
            @{ File = $rel; Count = $found.Count }
        }
    }
    
    if ($matches) {
        Write-Output "--- $($p.Name) ---"
        Write-Output "    Note: $($p.Note)"
        foreach ($m in $matches) {
            Write-Output "    $($m.File) ($($m.Count) occurrences)"
        }
        Write-Output ""
    }
}

# Now compare structural differences: missing files, extra files
Write-Output "=== Checking for missing WPF files ==="
$wpfFiles = Get-ChildItem $wpfDir -Recurse -Filter "*.xaml" | Where-Object {
    $_.FullName -notmatch "\\bin\\" -and $_.FullName -notmatch "\\obj\\" -and $_.Extension -eq ".xaml"
} | ForEach-Object { $_.FullName.Replace($wpfDir + "\", "") }

foreach ($wpfFile in $wpfFiles) {
    $avFile = $wpfFile -replace "\.xaml$", ".axaml"
    $avPath = Join-Path $avDir $avFile
    if (-not (Test-Path $avPath)) {
        Write-Output "  MISSING: $avFile (exists in WPF as $wpfFile)"
    }
}
