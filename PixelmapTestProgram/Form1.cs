using System.Diagnostics;
using PixelmapLibrary;
using PixelmapLibrary.Analysers;
using PixelmapLibrary.SpriteManagement;

namespace PixelmapTestProgram;

public partial class Form1 : Form
{
    private Bitmap _slowBitmap;
    private Bitmap _fastBitmap;
    private Pixelmap _fastBitmapPixelmap;
    private readonly StillImageSprite _niceStillColorSprite;
    private readonly FontMonochromeSprite _fontMonochromeSprite;

    public Form1()
    {
        _slowBitmap = new Bitmap(256, 256);
        _fastBitmap = Pixelmap.CreateCompatibleBitmap(256, 256);
        _fastBitmapPixelmap = new Pixelmap(_fastBitmap);
        _fontMonochromeSprite = FontMonochromeSprite.Create();
        _niceStillColorSprite = new StillImageSprite(@"..\..\..\..\simplecolorsprite.jpg");
        InitializeComponent();
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(Color.Red);

        using var slowBitmapHistogram = Histogram.Generate(_slowBitmap).GetBitmap();
        using var fastBitmapHistogram = Histogram.Generate(_fastBitmap).GetBitmap();

        e.Graphics.DrawImage(_slowBitmap, 10, 10);
        e.Graphics.DrawImage(slowBitmapHistogram, 10, 270);

        e.Graphics.DrawImage(_fastBitmap, 275, 10);
        e.Graphics.DrawImage(fastBitmapHistogram, 275, 270);

        using var b = new SolidBrush(Color.FromArgb(127, 0, 0, 0));
        e.Graphics.FillRectangle(b, 100, 100, 700, 700);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // Draw the old way
        var s = new Stopwatch();
        s.Start();

        for (var y = 0; y < 256; y++)
        {
            for (var x = 0; x < 256; x++)
            {
                _slowBitmap.SetPixel(x, y, Color.FromArgb(255 - x, y, x));
            }
        }

        s.Stop();
        Text = s.Elapsed + @"    ";
        Refresh();

        // Using the pixelmap
        s.Reset();
        s.Start();
        _fastBitmapPixelmap.LockBits();

        for (var y = 0; y < 256; y++)
        {
            for (var x = 0; x < 256; x++)
            {
                _fastBitmapPixelmap.SetPixel(x, y, Color.FromArgb(255 - x, y, x));
            }
        }

        _fastBitmapPixelmap.UnlockBits();
        s.Stop();
        Text += s.Elapsed.ToString();
        Refresh();

        // Adding a cyan tint
        _fastBitmapPixelmap.LockBits();

        for (var y = 0; y < 256; y++)
        {
            for (var x = 0; x < 256; x++)
            {
                _fastBitmapPixelmap.AddColor(x, y, -100, 100, 100);
            }
        }

        _fastBitmapPixelmap.UnlockBits();
        Refresh();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        _slowBitmap.Dispose();
        _slowBitmap = new Bitmap(@"..\..\..\..\testpicture2.jpg");

        _fastBitmap.Dispose();
        _fastBitmap = Pixelmap.CreateCompatibleBitmap(@"..\..\..\..\testpicture.jpg");
        _fastBitmapPixelmap = new Pixelmap(_fastBitmap);
        Invalidate();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        var s1 = new MonochromeSprite(8, 8, 1);
        s1.Set(1, 1);
        s1.Set(1, 2);
        s1.Set(2, 1);
        s1.Set(2, 2);
        _fastBitmapPixelmap.LockBits();
        _fastBitmapPixelmap.DrawSprite(s1, 0, 0, 0, Color.Black);
        _fastBitmapPixelmap.DrawSprite(s1, 0, 2, 2, Color.Red);
        _fastBitmapPixelmap.DrawSprite(s1, 0, 10, 10, Color.White);
        _fastBitmapPixelmap.DrawSprite(_fontMonochromeSprite, 30, 100, 100, Color.White);
        _fastBitmapPixelmap.DrawSprite(_fontMonochromeSprite, 31, 110, 110, Color.Red);
        _fastBitmapPixelmap.DrawSprite(_fontMonochromeSprite, 32, 120, 120, Color.DarkCyan);
        _fontMonochromeSprite.Draw(_fastBitmapPixelmap, 33, 130, 130, Color.Indigo);
        _fontMonochromeSprite.Draw(_fastBitmapPixelmap, 34, 140, 140, Color.Indigo);
        _fontMonochromeSprite.Draw(_fastBitmapPixelmap, 35, 150, 150, Color.Indigo);
        _fontMonochromeSprite.Draw(_fastBitmapPixelmap, 'A', 160, 170, Color.DarkRed);
        _fontMonochromeSprite.Draw(_fastBitmapPixelmap, 'b', 170, 180, Color.MediumBlue);
        _fontMonochromeSprite.Draw(_fastBitmapPixelmap, 'C', 180, 190, Color.Yellow);
        _fontMonochromeSprite.DrawOpaque(_fastBitmapPixelmap, "Hello world!", 10, 10, Color.White, Color.Black);
        _fastBitmapPixelmap.DrawSprite(_niceStillColorSprite, 10, 50);


        _fastBitmapPixelmap.UnlockBits();
        Invalidate();

        var f = FontMonochromeSprite.Create();
        _fastBitmapPixelmap.LockBits();
        _fastBitmapPixelmap.DrawSprite(f, 0, 30, 30, Color.Black);
        _fastBitmapPixelmap.UnlockBits();
        Invalidate();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        _fastBitmapPixelmap.LockBits();

        for (var y = 0; y < 256; y++)
        {
            for (var x = 0; x < 256; x++)
            {
                _fastBitmapPixelmap.SetPixel(x, y, Color.FromArgb(y, 0, 0));
            }
        }

        _fastBitmapPixelmap.UnlockBits();
        Refresh();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
}