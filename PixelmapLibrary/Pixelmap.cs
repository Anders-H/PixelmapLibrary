using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace PixelmapLibrary;

public class Pixelmap
{
    private readonly Bitmap _bitmap;
    private IntPtr _dataPointer;
    private BitmapData? _data;
    private byte[]? _pixels;
    public int Width { get; }
    public int Height { get; }

    public Pixelmap(Bitmap bitmap)
    {
        _bitmap = bitmap;
        Width = _bitmap.Width;
        Height = _bitmap.Height;
        _pixels = null;
        _dataPointer = IntPtr.Zero;
        _data = null;
    }

    public static Bitmap CreateCompatibleBitmap(int width, int height) =>
        new(width, height, PixelFormat.Format24bppRgb);

    public void LockBits()
    {
        var pixelCount = Width * Height;
        var rect = new Rectangle(0, 0, Width, Height);
        _data = _bitmap.LockBits(rect, ImageLockMode.ReadWrite, _bitmap.PixelFormat);
        _pixels = new byte[pixelCount * 3];
        _dataPointer = _data.Scan0;
        Marshal.Copy(_dataPointer, _pixels, 0, _pixels.Length);
    }

    public void UnlockBits()
    {
        Marshal.Copy(_pixels!, 0, _dataPointer, _pixels!.Length);
        _bitmap.UnlockBits(_data!);
    }

    public Color GetPixel(int x, int y)                                                                                                                           
    {
        var i = (y * Width + x) * 3;

        if (i > _pixels!.Length - 3)
            throw new IndexOutOfRangeException();

        var b = _pixels[i];
        var g = _pixels[i + 1];
        var r = _pixels[i + 2];
        return Color.FromArgb(r, g, b);
    }

    public void SetPixel(int x, int y, Color color)
    {
        var i = (y * Width + x) * 3;
        _pixels![i] = color.B;
        _pixels[i + 1] = color.G;
        _pixels[i + 2] = color.R;
    }
}