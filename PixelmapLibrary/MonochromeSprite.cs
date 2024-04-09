namespace PixelmapLibrary;

public class MonochromeSprite : ISprite
{
    public int Width { get; }
    public int Height { get; }
    private readonly bool[,] _pixels;

    public MonochromeSprite(int width, int height)
    {
        Width = width;
        Height = height;
        _pixels = new bool[width, height];
    }

    public void Set(int x, int y) =>
        _pixels[x, y] = true;

    public bool Get(int x, int y) =>
        _pixels[x, y];
}