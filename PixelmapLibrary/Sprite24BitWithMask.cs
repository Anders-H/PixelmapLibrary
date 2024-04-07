namespace PixelmapLibrary;

public class Sprite24BitWithMask
{
    private readonly byte[,] _red;
    private readonly byte[,] _green;
    private readonly byte[,] _blue;
    private readonly bool[,] _mask;

    public Sprite24BitWithMask(int width, int height)
    {
        _red = new byte[width, height];
        _green = new byte[width, height];
        _blue = new byte[width, height];
        _mask = new bool[width, height];
    }
}