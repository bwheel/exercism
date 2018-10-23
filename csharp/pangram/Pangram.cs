using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Pangram
{
    private  static Dictionary<char, int> letterCounts = new Dictionary<char, int>()
    {       
        {'a', 0},
        {'b', 0},
        {'c', 0},
        {'d', 0},
        {'e', 0},
        {'f', 0},
        {'g', 0},
        {'h', 0},
        {'i', 0},
        {'j', 0},
        {'k', 0},
        {'l', 0},
        {'m', 0},
        {'n', 0},
        {'o', 0},
        {'p', 0},
        {'q', 0},
        {'r', 0},
        {'s', 0},
        {'t', 0},
        {'u', 0},
        {'v', 0},
        {'w', 0},
        {'x', 0},
        {'y', 0},
        {'z', 0},
    };

    public static bool IsPangram(string input)
    {
        //string filteredInput = Regex.Replace(input.ToLower(), "([^a-z])", "");
        foreach (var letter in input.ToLower().ToCharArray())
        {
            if(letterCounts.ContainsKey(letter))
            {
                letterCounts[letter]++;
            }
        }
        return letterCounts.Values.Count( ( val) => { return val > 0; }) == letterCounts.Count;
    }
}
