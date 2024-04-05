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

    }
}