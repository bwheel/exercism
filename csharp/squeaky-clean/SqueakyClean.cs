using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


public static class Identifier
{
    public static string Clean(string identifier)
        => string.Join("", clean(identifier));

    private static bool IsGreekLetter(char c)
        => (c >= 'α' && c <= 'ω');
    private static string mapLetter(char c)
        => c switch
        {
            ' ' => "_",
            char l when Char.IsControl(l) => "CTRL",
            char l when IsGreekLetter(l) => "",
            char l when Char.IsLetter(l) => l.ToString(),
            _ => "",
        };


    private static IEnumerable<string> clean(string identifier)
    {
        int index = 0;
        while (index < identifier.Length)
        {
            char c = identifier[index];
            if (c != '-')
            {
                yield return mapLetter(c);
            }
            else
            {
                yield return (index + 1) < identifier.Length ? Char.ToUpper(identifier[++index]).ToString() : "";
            }
            index++;
        }
    }
}
