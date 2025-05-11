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
        pixelmap.Clear(Color.Black);

        for (var y = 0; y < 100; y++)
        {
            for (var x = 0; x < 256; x++)
            {
                var r = (int)Math.Round(Red[x]);
                var g = (int)Math.Round(Green[x]);
                var b = (int)Math.Round(Blue[x]);

                if (r >= y)
                    pixelmap.AddColor(x, 99 - y, 140, 0, 0);

                if (g >= y)
                    pixelmap.AddColor(x, 99 - y, 0, 140, 0);
                
                if (b >= y)
                    pixelmap.AddColor(x, 99 - y, 0, 0, 140);
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

        var highPoint = result.Red.Length - (result.Red.Length / 25);

        var largeByColor = new double[3];
        largeByColor[0] = result.Red.OrderBy(x => x).ToList()[highPoint];
        largeByColor[1] = result.Green.OrderBy(x => x).ToList()[highPoint];
        largeByColor[2] = result.Blue.OrderBy(x => x).ToList()[highPoint];
        var large = largeByColor.MaxBy(x => x);

        for (var i = 0; i < 256; i++)
        {
            var percent = (float)((result.Red[i] / large) * 100.0);
            result.Red[i] = percent;
            percent = (float)((result.Green[i] / large) * 100.0);
            result.Green[i] = percent;
            percent = (float)((result.Blue[i] / large) * 100.0);
            result.Blue[i] = percent;
        }

        return result;
    }
}