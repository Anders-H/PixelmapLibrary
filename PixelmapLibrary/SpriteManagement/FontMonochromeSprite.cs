﻿using PixelmapLibrary.FontManagement;

namespace PixelmapLibrary.SpriteManagement;

public class FontMonochromeSprite : MonochromeSprite
{
    private readonly TerminalCodePage _codePage;

    private FontMonochromeSprite(int count) : base(8, 8, count)
    {
        _codePage = new TerminalCodePage();
    }

    public static FontMonochromeSprite Create()
    {
        var terminalFont = new TerminalFont();
        var result = new FontMonochromeSprite(terminalFont.Count);
        result.SetData(terminalFont);
        return result;
    }

    private void SetData(TerminalFont terminalFont)
    {
        for (var i = 0; i < terminalFont.Count; i++)
            SetData(i, terminalFont[i]);
    }

    private void SetData(int plane, CharacterPixelMatrix pixels)
    {
        CurrentPlane = plane;

        for (var y = 0; y < 8; y++)
        {
            for (var x = 0; x < 8; x++)
            {
                Set(x, y, pixels.Pixels[x, y]);
            }
        }
    }
}