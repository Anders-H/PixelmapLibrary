﻿using System.Collections;

namespace PixelmapLibrary.FontManagement;

public class TerminalFont : IReadOnlyDictionary<char, CharacterPixelMatrix>
{
    private readonly Dictionary<char, CharacterPixelMatrix> _data;

    public TerminalFont()
    {
        _data = new Dictionary<char, CharacterPixelMatrix>
        {
            {
                ' ', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,,"
                )
            },
            {
                '@', new CharacterPixelMatrix(
                    ",,****,," +
                    ",*,,,,*," +
                    "*,,**,,*" +
                    "*,*,,*,*" +
                    "*,,*,*,*" +
                    ",*,,,,*," +
                    ",,,**,,," +
                    ",,,,,,,,"
                )
            },
            {
                '(', new CharacterPixelMatrix(
                    ",,,,**,," +
                    ",,,**,,," +
                    ",,**,,,," +
                    ",,**,,,," +
                    ",,**,,,," +
                    ",,**,,,," +
                    ",,,**,,," +
                    ",,,,**,,"
                )
            },
            {
                ')', new CharacterPixelMatrix(
                    ",,**,,,," +
                    ",,,**,,," +
                    ",,,,**,," +
                    ",,,,**,," +
                    ",,,,**,," +
                    ",,,,**,," +
                    ",,,**,,," +
                    ",,**,,,,"
                )
            },
            {
                '<', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,**,," +
                    ",,,**,,," +
                    ",,**,,,," +
                    ",,**,,,," +
                    ",,,**,,," +
                    ",,,,**,," +
                    ",,,,,,,,"
                )
            },
            {
                '>', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,**,,,," +
                    ",,,**,,," +
                    ",,,,**,," +
                    ",,,,**,," +
                    ",,,**,,," +
                    ",,**,,,," +
                    ",,,,,,,,"
                )
            },
            {
                '#', new CharacterPixelMatrix(
                    ",,*,,*,," +
                    ",******," +
                    ",,*,,*,," +
                    ",,*,,*,," +
                    ",,*,,*,," +
                    ",******," +
                    ",,*,,*,," +
                    ",,,,,,,,"
                )
            },
            {
                '$', new CharacterPixelMatrix(
                    ",,,**,,," +
                    ",,****,," +
                    ",**,,,,," +
                    ",,****,," +
                    ",,,,,**," +
                    ",,****,," +
                    ",,,**,,," +
                    ",,,,,,,,"
                )
            },
            {
                '&', new CharacterPixelMatrix(
                    ",,,***,," +
                    ",,*,,,*," +
                    ",,*,,*'," +
                    ",,,**,,," +
                    ",,*,*,*," +
                    ",*,,,*,," +
                    ",,***,*," +
                    ",,,,,,,,"
                )
            },
            {
                ':', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,,,,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,,,,,,"
                )
            },
            {
                '+', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",******," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,,,,,," +
                    ",,,,,,,,"
                )
            },
            {
                '*', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,*,,,*," +
                    ",,,*,*,," +
                    ",,*****," +
                    ",,,*,*,," +
                    ",,*,,,*," +
                    ",,,,,,,," +
                    ",,,,,,,,"
                )
            },
            {
                '/', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,**,," +
                    ",,,,**,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,**,,,," +
                    ",,**,,,," +
                    ",,,,,,,,"
                )
            },
            {
                '\\', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,**,,,," +
                    ",,**,,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,,**,," +
                    ",,,,**,," +
                    ",,,,,,,,"
                )
            },
            {
                '%', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    "**,,**,," +
                    "**,,**,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,**,,**" +
                    ",,**,,**" +
                    ",,,,,,,,"
                )
            },
            {
                ',', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,**,,,,"
                )
            },
            {
                ';', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,**,,," +
                    ",,,,,,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,**,,,,"
                )
            },
            {
                '.', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,,,,,,"
                )
            },
            {
                '"', new CharacterPixelMatrix(
                    ",**,,**," +
                    ",**,,**," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,,"
                )
            },
            {
                '\'', new CharacterPixelMatrix(
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,,"
                )
            },
            {
                '0', new CharacterPixelMatrix(
                    ",,****,," +
                    ",**,,**," +
                    ",**,***," +
                    ",******," +
                    ",***,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                '!', new CharacterPixelMatrix(
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,,,,,," +
                    ",,,**,,," +
                    ",,,,,,,,"
                )
            },
            {
                '?', new CharacterPixelMatrix(
                    ",,****,," +
                    ",**,,**," +
                    ",,,,,**," +
                    ",,,,**,," +
                    ",,,**,,," +
                    ",,,,,,,," +
                    ",,,**,,," +
                    ",,,,,,,,"
                )
            },
            {
                '1', new CharacterPixelMatrix(
                    ",,,**,,," +
                    ",,***,,," +
                    ",****,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",******," +
                    ",,,,,,,,"
                )
            },
            {
                '2', new CharacterPixelMatrix(
                    ",,****,," +
                    ",**,,**," +
                    ",,,, **," +
                    ",,, **,," +
                    ",, **,,," +
                    ", **,,,," +
                    ",******," +
                    ",,,,,,,,"
                )
            },
            {
                '3', new CharacterPixelMatrix(
                    ",,****,," +
                    ",**,,**," +
                    ",,,,,**," +
                    ",,,,**,," +
                    ",,,,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                '4', new CharacterPixelMatrix(
                    ",,,,***," +
                    ",,,****," +
                    ",,**,**," +
                    ",**,,**," +
                    ",******," +
                    ",,,,,**," +
                    ",,,,,**," +
                    ",,,,,,,,"
                )
            },
            {
                '5', new CharacterPixelMatrix(
                    ",******," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",*****,," +
                    ",,,,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                '6', new CharacterPixelMatrix(
                    ",,****,," +
                    ",**,,**," +
                    ",**,,,,," +
                    ",*****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                '7', new CharacterPixelMatrix(
                    ",******," +
                    ",,,,,**," +
                    ",,,,,**," +
                    ",,,,**,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,,,,,,"
                )
            },
            {
                '8', new CharacterPixelMatrix(
                    ",,****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                '9', new CharacterPixelMatrix(
                    ",,****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,*****," +
                    ",,,,,**," +
                    ",,,,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                'A', new CharacterPixelMatrix(
                    ",,,**,,," +
                    ",,****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",******," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,,,,,,,"
                )
            },
            {
                'a', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,****,," +
                    ",,,,,**," +
                    ",,*****," +
                    ",**,,**," +
                    ",,*****," +
                    ",,,,,,,,"
                )
            },
            {
                'B', new CharacterPixelMatrix(
                    ",*****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",*****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",*****,," +
                    ",,,,,,,,"
                )
            },
            {
                'b', new CharacterPixelMatrix(
                    ",**,,,,," +
                    ",**,,,,," +
                    ",*****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",*****,," +
                    ",,,,,,,,"
                )
            },
            {
                'C', new CharacterPixelMatrix(
                    ",,****,," +
                    ",**,,**," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                'c', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,****,," +
                    ",**,,**," +
                    ",**,,,,," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                'D', new CharacterPixelMatrix(
                    ",****,,," +
                    ",**,**,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,**,," +
                    ",****,,," +
                    ",,,,,,,,"
                )
            },
            {
                'd', new CharacterPixelMatrix(
                    ",,,,,**," +
                    ",,,,,**," +
                    ",,*****," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,'**," +
                    ",,*****," +
                    ",,,,,,,,"
                )
            },
            {
                'E', new CharacterPixelMatrix(
                    ",******," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",****,,," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",******," +
                    ",,,,,,,,"
                )
            },
            {
                'e', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,****,," +
                    ",**,,**," +
                    ",******," +
                    ",**,,,,," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                'F', new CharacterPixelMatrix(
                    ",******," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",****,,," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",,,,,,,,"
                )
            },
            {
                'f', new CharacterPixelMatrix(
                    ",,,****," +
                    ",,**,,,," +
                    ",,**,,,," +
                    ",****,,," +
                    ",,**,,,," +
                    ",,**,,,," +
                    ",,**,,,," +
                    ",,,,,,,,"
                )
            },
            {
                'G', new CharacterPixelMatrix(
                    ",,****,," +
                    ",**,,**," +
                    ",**,,,,," +
                    ",**,***," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                'g', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,*****," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,*****," +
                    ",,,,,**," +
                    ",,****,,"
                )
            },
            {
                'H', new CharacterPixelMatrix(
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",******," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,,,,,,,"
                )
            },
            {
                'h', new CharacterPixelMatrix(
                    ",**,,,,," +
                    ",**,,,,," +
                    ",*****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,,,,,,,"
                )
            },
            {
                'I', new CharacterPixelMatrix(
                    ",,****,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                'i', new CharacterPixelMatrix(
                    ",,,**,,," +
                    ",,,,,,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,,,,,,"
                )
            },
            {
                'J', new CharacterPixelMatrix(
                    ",,,****," +
                    ",,,,,**," +
                    ",,,,,**," +
                    ",,,,,**," +
                    ",,,,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                'j', new CharacterPixelMatrix(
                    ",,,,,**," +
                    ",,,,,,,," +
                    ",,,,,**," +
                    ",,,,,**," +
                    ",,,,,**," +
                    ",,,,,**," +
                    ",**,,**," +
                    ",,****,,"
                )
            },
            {
                'K', new CharacterPixelMatrix(
                    ",**,,**," +
                    ",**,,**," +
                    ",**,**,," +
                    ",****,,," +
                    ",**,**,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,,,,,,,"
                )
            },
            {
                'k', new CharacterPixelMatrix(
                    ",**,,,,," +
                    ",**,,,,," +
                    ",**,,**," +
                    ",**,**,," +
                    ",****,,," +
                    ",**,**,," +
                    ",**,,**," +
                    ",,,,,,,,"
                )
            },
            {
                'L', new CharacterPixelMatrix(
                    ",**,,,,," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",******," +
                    ",,,,,,,,"
                )
            },
            {
                'l', new CharacterPixelMatrix(
                    ",,***,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                'M', new CharacterPixelMatrix(
                    ",**,,,**" +
                    ",***,***" +
                    ",*******" +
                    ",**,*,**" +
                    ",**,,,**" +
                    ",**,,,**" +
                    ",**,,,**" +
                    ",,,,,,,,"
                )
            },
            {
                'm', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",***,**," +
                    ",*******" +
                    ",**,*,**" +
                    ",**,,,**" +
                    ",**,,,**" +
                    ",,,,,,,,"
                )
            },
            {
                'N', new CharacterPixelMatrix(
                    ",**,,**," +
                    ",***,**," +
                    ",******," +
                    ",**,***," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,,,,,,,"
                )
            },
            {
                'n', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",******," +
                    ",**,,,**" +
                    ",**,,,**" +
                    ",**,,,**" +
                    ",**,,,**" +
                    ",,,,,,,,"
                )
            },
            {
                'O', new CharacterPixelMatrix(
                    ",,****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                'o', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                'P', new CharacterPixelMatrix(
                    ",*****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",*****,," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",,,,,,,,"
                )
            },
            {
                'p', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",*****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",*****,," +
                    ",**,,,,," +
                    ",**,,,,,"
                )
            },
            {
                'Q', new CharacterPixelMatrix(
                    ",,****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,**,"
                )
            },
            {
                'q', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,*****," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,*****," +
                    ",,,,,**," +
                    ",,,,,**,"
                )
            },
            {
                'R', new CharacterPixelMatrix(
                    ",*****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",*****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,,,,,,,"
                )
            },
            {
                'r', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",*****,," +
                    ",**,,**," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",**,,,,," +
                    ",,,,,,,,"
                )
            },
            {
                'S', new CharacterPixelMatrix(
                    ",,****,," +
                    ",**,,**," +
                    ",**,,,,," +
                    ",,****,," +
                    ",,,,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                's', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,****,," +
                    ",**,,,,," +
                    ",,****,," +
                    ",,,,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                'T', new CharacterPixelMatrix(
                    ",******," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,,,,,,"
                )
            },
            {
                't', new CharacterPixelMatrix(
                    ",,**,,,," +
                    ",,**,,,," +
                    ",*****,," +
                    ",,**,,,," +
                    ",,**,,,," +
                    ",,**,,,," +
                    ",,,****," +
                    ",,,,,,,,,"
                )
            },
            {
                'U', new CharacterPixelMatrix(
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                'u', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,,,,,,"
                )
            },
            {
                'V', new CharacterPixelMatrix(
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,**,,," +
                    ",,,,,,,,"
                )
            },
            {
                'v', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,**,,," +
                    ",,,,,,,,"
                )
            },
            {
                'W', new CharacterPixelMatrix(
                    ",**,,,**" +
                    ",**,,,**" +
                    ",**,,,**" +
                    ",**,*,**" +
                    ",*******" +
                    ",***,***" +
                    ",**,,,**" +
                    ",,,,,,,,"
                )
            },
            {
                'w', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",**,,,**" +
                    ",**,*,**" +
                    ",*******" +
                    ",***,***" +
                    ",**,,,**" +
                    ",,,,,,,,,"
                )
            },
            {
                'X', new CharacterPixelMatrix(
                    ",**,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,**,,," +
                    ",,****,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,,,,,,,"
                )
            },
            {
                'x', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,**,,," +
                    ",,****,," +
                    ",**,,**," +
                    ",,,,,,,,"
                )
            },
            {
                'Y', new CharacterPixelMatrix(
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,****,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,**,,," +
                    ",,,,,,,,"
                )
            },
            {
                'y', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",**,,**," +
                    ",**,,**," +
                    ",**,,**," +
                    ",,*****," +
                    ",,,,,**," +
                    ",,****,,"
                )
            },
            {
                'Z', new CharacterPixelMatrix(
                    ",******," +
                    ",,,,,**," +
                    ",,,,**,," +
                    ",,'**,,," +
                    ",,**,,,," +
                    ",**,,,,," +
                    ",******," +
                    ",,,,,,,,"
                )
            },
            {
                'z', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",******," +
                    ",,,,**,," +
                    ",,,**,,," +
                    ",,**,,,," +
                    ",******," +
                    ",,,,,,,,"
                )
            },
            {
                '-', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",******," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,,"
                )
            },
            {
                '=', new CharacterPixelMatrix(
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",******," +
                    ",,,,,,,," +
                    ",******," +
                    ",,,,,,,," +
                    ",,,,,,,," +
                    ",,,,,,,,"
                )
            }
        };
    }

    public IEnumerator<KeyValuePair<char, CharacterPixelMatrix>> GetEnumerator() =>
        _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        _data.GetEnumerator();

    public int Count =>
        _data.Count;

    public bool ContainsKey(char key) =>
        _data.ContainsKey(key);

#pragma warning disable CS8601 // Possible null reference assignment.
    public bool TryGetValue(char key, out CharacterPixelMatrix value) =>
        _data.TryGetValue(key, out value);
#pragma warning restore CS8601 // Possible null reference assignment.

    public CharacterPixelMatrix this[int index] =>
        _data.ElementAt(index).Value;

    public CharacterPixelMatrix this[char key] =>
        _data[key];

    public IEnumerable<char> Keys =>
        _data.Keys;

    public IEnumerable<CharacterPixelMatrix> Values =>
        _data.Values;
}