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
        _pixels = null;
        _dataPointer = IntPtr.Zero;
        _data = null;
        Width = _bitmap.Width;
        Height = _bitmap.Height;
    }

    public static Bitmap CreateCompatibleBitmap(int width, int height) =>
        new(width, height, PixelFormat.Format24bppRgb);

    public static Bitmap CreateCompatibleBitmap(string filename)
    {
        var bitmap = new Bitmap(filename);
        var result = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format24bppRgb);

        for (var y = 0; y < bitmap.Height; y++)
        {
            for (var x = 0; x < bitmap.Width; x++)
            {
                result.SetPixel(x, y, bitmap.GetPixel(x, y));
            }
        }

        return result;
    }

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
        GetRgb(x, y, out var r, out var g, out var b);
        return Color.FromArgb(r, g, b);
    }

    public Color RangeSafeGetPixel(int x, int y)
    {
        if (x < 0 || y >= Width || y < 0 || y >= Height)
            return Color.Black;

        GetRgb(x, y, out var r, out var g, out var b);
        return Color.FromArgb(r, g, b);
    }

    public void GetRgb(int x, int y, out int r, out int g, out int b)
    {
        var i = (y * Width + x) * 3;

        if (i > _pixels!.Length - 3)
            throw new IndexOutOfRangeException();

        b = _pixels[i];
        g = _pixels[i + 1];
        r = _pixels[i + 2];
    }

    public void RangeSafeGetRgb(int x, int y, out int r, out int g, out int b)
    {
        if (x < 0 || y >= Width || y < 0 || y >= Height)
        {
            r = 0;
            g = 0;
            b = 0;
            return;
        }

        var i = (y * Width + x) * 3;

        if (i > _pixels!.Length - 3)
            throw new IndexOutOfRangeException();

        b = _pixels[i];
        g = _pixels[i + 1];
        r = _pixels[i + 2];
    }

    public void SetPixel(int x, int y, Color color)
    {
        var i = (y * Width + x) * 3;
        _pixels![i] = color.B;
        _pixels[i + 1] = color.G;
        _pixels[i + 2] = color.R;
    }

    public void RangeSafeSetPixel(int x, int y, Color color)
    {
        if (x < 0 || y >= Width || y < 0 || y >= Height)
            return;

        var i = (y * Width + x) * 3;
        _pixels![i] = color.B;
        _pixels[i + 1] = color.G;
        _pixels[i + 2] = color.R;
    }

    public void SetPixel(int x, int y, int r, int g, int b)
    {
        var i = (y * Width + x) * 3;
        _pixels![i] = (byte)b;
        _pixels[i + 1] = (byte)g;
        _pixels[i + 2] = (byte)r;
    }

    public void RangeSafeSetPixel(int x, int y, int r, int g, int b)
    {
        if (x < 0 || y >= Width || y < 0 || y >= Height)
            return;

        var i = (y * Width + x) * 3;
        _pixels![i] = (byte)b;
        _pixels[i + 1] = (byte)g;
        _pixels[i + 2] = (byte)r;
    }

    public void AddColor(int x, int y, int r, int g, int b)
    {
        GetRgb(x, y, out var sr, out var sg, out var sb);
        sr += r;
        sg += g;
        sb += b;

        if (sr < 0)
            sr = 0;
        else if (sr > 255)
            sr = 255;

        if (sg < 0)
            sg = 0;
        else if (sg > 255)
            sg = 255;

        if (sb < 0)
            sb = 0;
        else if (sb > 255)
            sb = 255;

        SetPixel(x, y, sr, sg, sb);
    }

    public void RangeSafeAddColor(int x, int y, int r, int g, int b)
    {
        if (x < 0 || y >= Width || y < 0 || y >= Height)
            return;

        AddColor(x, y, r, g, b);
    }
}