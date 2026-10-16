using System.Drawing;
using System.Drawing.Imaging;
using PixelmapLibrary;
using PixelmapLibrary.FontManagement;

static void Assert(bool condition, string message)
{
    if (!condition) throw new Exception(message);
}

foreach (var (width, height) in new[] { (1, 7), (3, 7), (4, 7), (5, 7), (7, 3) })
{
    using var bitmap = Pixelmap.CreateCompatibleBitmap(width, height);
    for (var y = 0; y < height; y++)
        for (var x = 0; x < width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(10 + x, 20 + y, 30));
    var map = new Pixelmap(bitmap);
    map.LockBits();
    try
    {
        for (var y = 0; y < height; y++)
            for (var x = 0; x < width; x++)
            {
                Assert(map.RangeSafeGetPixel(x, y).ToArgb() == Color.FromArgb(10 + x, 20 + y, 30).ToArgb(), "Read failed");
                map.RangeSafeSetPixel(x, y, Color.Red);
            }
        foreach (var (x, y) in new[] { (-1, 0), (width, 0), (0, -1), (0, height) })
        {
            Assert(map.RangeSafeGetPixel(x, y).ToArgb() == Color.Black.ToArgb(), "Outside read failed");
            map.RangeSafeGetRgb(x, y, out var r, out var g, out var b);
            Assert(r == 0 && g == 0 && b == 0, "Outside RGB failed");
            map.RangeSafeSetPixel(x, y, Color.Blue);
            map.RangeSafeSetPixel(x, y, 0, 0, 255);
            map.RangeSafeAddColor(x, y, -255, 0, 255);
        }
        map.RangeSafeSetPixel(0, height - 1, 10, 20, 30);
        map.RangeSafeAddColor(0, height - 1, 5, 6, 7);
    }
    finally { map.UnlockBits(); }
    for (var y = 0; y < height; y++)
        for (var x = 0; x < width; x++)
            Assert(bitmap.GetPixel(x, y).ToArgb() == (x == 0 && y == height - 1 ? Color.FromArgb(15, 26, 37) : Color.Red).ToArgb(), "Write failed");
    map.LockBits();
    map.UnlockBits();
}
using (var bitmap = new Bitmap(2, 2, PixelFormat.Format32bppArgb))
{
    var rejected = false;
    try { _ = new Pixelmap(bitmap); } catch (ArgumentException) { rejected = true; }
    Assert(rejected, "32-bit format must be rejected");
}
var filename = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".png");
try
{
    using (var source = new Bitmap(5, 3))
    {
        source.SetPixel(2, 1, Color.Lime);
        source.Save(filename, ImageFormat.Png);
    }
    using var converted = Pixelmap.CreateCompatibleBitmap(filename);
    Assert(converted.PixelFormat == PixelFormat.Format24bppRgb, "Conversion format failed");
    Assert(converted.GetPixel(2, 1).ToArgb() == Color.Lime.ToArgb(), "Conversion color failed");
    using var stream = File.Open(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
}
finally { File.Delete(filename); }
var matrix = new CharacterPixelMatrix("*" + new string(',', 63));
Assert(matrix.Pixels[0, 0] && !matrix.Pixels[7, 7], "Font pixels failed");
Console.WriteLine("All regression checks passed.");
