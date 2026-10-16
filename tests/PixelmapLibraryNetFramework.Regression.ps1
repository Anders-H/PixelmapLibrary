$ErrorActionPreference = 'Stop'
Add-Type -AssemblyName System.Drawing
Add-Type -Path (Join-Path $PSScriptRoot '../PixelmapLibraryNetFramework/bin/Release/PixelmapLibraryNetFramework.dll')
function Assert($condition, $message) { if (-not $condition) { throw $message } }
foreach ($width in @(1, 3, 4, 5)) {
    $bitmap = [PixelmapLibraryNetFramework.Pixelmap]::CreateCompatibleBitmap($width, 7)
    try {
        for ($y = 0; $y -lt 7; $y++) {
            for ($x = 0; $x -lt $width; $x++) {
                $bitmap.SetPixel($x, $y, [Drawing.Color]::FromArgb(10 + $x, 20 + $y, 30))
            }
        }
        $map = [PixelmapLibraryNetFramework.Pixelmap]::new($bitmap)
        $map.LockBits()
        for ($y = 0; $y -lt 7; $y++) {
            for ($x = 0; $x -lt $width; $x++) {
                Assert ($map.RangeSafeGetPixel($x, $y).ToArgb() -eq [Drawing.Color]::FromArgb(10 + $x, 20 + $y, 30).ToArgb()) "Read failed: $width/$x/$y"
                $map.RangeSafeSetPixel($x, $y, [Drawing.Color]::Red)
            }
        }
        foreach ($point in @(@(-1, 0), @($width, 0), @(0, -1), @(0, 7))) {
            $x = $point[0]; $y = $point[1]
            Assert ($map.RangeSafeGetPixel($x, $y).ToArgb() -eq [Drawing.Color]::Black.ToArgb()) 'Outside pixel should be black'
            $r = 1; $g = 1; $b = 1
            $map.RangeSafeGetRgb($x, $y, [ref]$r, [ref]$g, [ref]$b)
            Assert (($r + $g + $b) -eq 0) 'Outside RGB should be zero'
            $map.RangeSafeSetPixel($x, $y, [Drawing.Color]::Blue)
            $map.RangeSafeSetPixel($x, $y, 0, 0, 255)
            $map.RangeSafeAddColor($x, $y, -255, 0, 255)
        }
        $map.RangeSafeSetPixel(0, 6, 10, 20, 30)
        $map.RangeSafeAddColor(0, 6, 5, 6, 7)
        $map.UnlockBits()
        for ($y = 0; $y -lt 7; $y++) {
            for ($x = 0; $x -lt $width; $x++) {
                $expected = [Drawing.Color]::Red
                if ($x -eq 0 -and $y -eq 6) { $expected = [Drawing.Color]::FromArgb(15, 26, 37) }
                Assert ($bitmap.GetPixel($x, $y).ToArgb() -eq $expected.ToArgb()) "Write failed: $width/$x/$y"
            }
        }
        $map.LockBits(); $map.UnlockBits()
    } finally { $bitmap.Dispose() }
}
$bitmap = [Drawing.Bitmap]::new(2, 2, [Drawing.Imaging.PixelFormat]::Format32bppArgb)
try {
    $rejected = $false
    try { $null = [PixelmapLibraryNetFramework.Pixelmap]::new($bitmap) } catch { $rejected = $true }
    Assert $rejected '32-bit format must be rejected'
} finally { $bitmap.Dispose() }
$filename = Join-Path ([IO.Path]::GetTempPath()) ([Guid]::NewGuid().ToString() + '.png')
$source = [Drawing.Bitmap]::new(5, 3)
try {
    $source.SetPixel(2, 1, [Drawing.Color]::Lime)
    $source.Save($filename, [Drawing.Imaging.ImageFormat]::Png)
} finally { $source.Dispose() }
try {
    $converted = [PixelmapLibraryNetFramework.Pixelmap]::CreateCompatibleBitmap($filename)
    try {
        Assert ($converted.PixelFormat -eq [Drawing.Imaging.PixelFormat]::Format24bppRgb) 'Conversion format failed'
        Assert ($converted.GetPixel(2, 1).ToArgb() -eq [Drawing.Color]::Lime.ToArgb()) 'Conversion color failed'
        $stream = [IO.File]::Open($filename, 'Open', 'ReadWrite', 'None')
        $stream.Dispose()
    } finally { $converted.Dispose() }
} finally { Remove-Item -LiteralPath $filename }
$matrix = [PixelmapLibraryNetFramework.FontManagement.CharacterPixelMatrix]::new('*' + (',' * 63))
Assert $matrix.Pixels[0, 0] 'Font foreground failed'
Assert (-not $matrix.Pixels[7, 7]) 'Font background failed'
Write-Output 'All regression checks passed.'

