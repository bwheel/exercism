using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        if( !Regex.Match(sequence, "^([ACGTacgt]{0,})$").Success)
        {
            throw new ArgumentException();
        }

        Dictionary<char, int> result = new Dictionary<char, int>()
        {
            {'A', 0},
            {'C', 0},
            {'G', 0},
            {'T', 0}
        };
        
        foreach(char c in sequence.ToUpper())
        {
            result[c]++;
        }
        
        return result;
    }
}