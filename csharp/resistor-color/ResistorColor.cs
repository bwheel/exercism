using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public static class ResistorColor
{

    private static readonly string[] s_colors = ["black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"];
    private static readonly IDictionary<string, int> s_colorMapping =
        new ReadOnlyDictionary<string, int>(
            s_colors
                .Select((val, idx) => new { val, idx })
                .ToDictionary(pair => pair.val, pair => pair.idx));

    public static int ColorCode(string color) => s_colorMapping[color];

    public static string[] Colors() => s_colors;

}