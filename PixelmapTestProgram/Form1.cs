using System.Diagnostics;
using PixelmapLibrary;

namespace PixelmapTestProgram;

public partial class Form1 : Form
{
    private readonly Bitmap _slowBitmap;
    private readonly Bitmap _fastBitmap;
    private readonly Pixelmap _fastBitmapPixelmap;

    public Form1()
    {
        _slowBitmap = new Bitmap(256, 256);
        _fastBitmap = Pixelmap.CreateCompatibleBitmap(256, 256);
        _fastBitmapPixelmap = new Pixelmap(_fastBitmap);
        InitializeComponent();
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(Color.Red);
        e.Graphics.DrawImage(_slowBitmap, 10, 10);
        e.Graphics.DrawImage(_fastBitmap, 300, 10);
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
        Text = s.Elapsed + "    ";
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
                _fastBitmapPixelmap.AddColor(x, y, -200, 200, 200);
            }
        }
        _fastBitmapPixelmap.UnlockBits();

        Refresh();
    }
}