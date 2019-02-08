using System;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        return string.IsNullOrWhiteSpace(word) ||
                    word
                    .Replace("-","")  // don't count hyphens
                    .Replace(" ", "") // don't count spaces
                    .ToLower()        // case insensitive.
                    .ToArray()        // convert to collection
                    .GroupBy( c => c ) // group by individusl letters
                    .Where( c => c.Count() > 1) // filter out non multiples
                    .Count() < 1; // if there are no matches, it's an isogram.
    }
}
