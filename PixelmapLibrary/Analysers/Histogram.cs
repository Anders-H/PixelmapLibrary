using System.Drawing;

namespace PixelmapLibrary.Analysers;

public class Histogram
{
    public float[] Red { get; } = new float[256];
    public float[] Green { get; } = new float[256];
    public float[] Blue { get; } = new float[256];

    private Histogram()
    {
    }

    public Bitmap GetBitmap()
    {
        var bitmap = Pixelmap.CreateCompatibleBitmap(256, 100);
        var pixelmap = new Pixelmap(bitmap);
        pixelmap.LockBits();
        pixelmap.Clear(Color.White);


        for (var y = 0; y < 100; y++)
        {
            for (var x = 0; x < 256; x++)
            {
                var r = (int)Math.Round(Red[x]);
                var g = (int)Math.Round(Green[x]);
                var b = (int)Math.Round(Blue[x]);

                if (r >= y)
                    pixelmap.AddColor(x, y, 0, -120, -120);

                if (g >= y)
                    pixelmap.AddColor(x, y, -120, 0, -120);
                
                if (b >= y)
                    pixelmap.AddColor(x, y, -120, -120, 0);
            }
        }

        pixelmap.UnlockBits();
        return bitmap;
    }

    public static Histogram Generate(Bitmap bitmap)
    {
        var result = new Histogram();

        for (var y = 0; y < bitmap.Height; y++)
        {
            for (var x = 0; x < bitmap.Width; x++)
            {
                var c = bitmap.GetPixel(x, y);
                result.Red[c.R] += 1;
                result.Green[c.G] += 1;
                result.Blue[c.B] += 1;
            }
        }

        var highest = new float[3];
        highest[0] = result.Red.MaxBy(x => x);
        highest[1] = result.Green.MaxBy(x => x);
        highest[2] = result.Blue.MaxBy(x => x);
        var max = highest.MaxBy(x => x);

        for (var i = 0; i < 256; i++)
        {
            var percent = (float)((result.Red[i] / max) * 100.0);
            result.Red[i] = percent;
            percent = (float)((result.Green[i] / max) * 100.0);
            result.Green[i] = percent;
            percent = (float)((result.Blue[i] / max) * 100.0);
            result.Blue[i] = percent;
        }

        return result;
    }
}