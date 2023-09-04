using System;
using System.Linq;
using System.Text;

public static class RunLengthEncoding
{
    private static string formatAbbreviated(int count, char letter)
        => count switch
        {
            > 1 => $"{count}{letter}",
            _ => $"{letter}",
        };

    public static string Encode(string input)
    {
        StringBuilder sb = new StringBuilder();
        while (input.Length > 0)
        {
            char letter = input[0];
            var similarGroup = input.TakeWhile(l => l == letter).ToArray();
            sb.Append(formatAbbreviated(similarGroup.Length, letter));
            input = input[similarGroup.Length..];
        }
        var actual = sb.ToString();
        return actual;
    }
    private static string formatSequence(int count, char letter)
        => string.Concat(Enumerable.Repeat(letter, count));
    private static bool isNumber(char l)
        => isNumber(l.ToString());
    private static bool isNumber(string s)
        => int.TryParse(s, out int _);
    public static string Decode(string input)
    {
        StringBuilder sb = new StringBuilder();
        while (input.Length > 0)
        {
            var digits = string.Concat(input.TakeWhile(s => isNumber(s)));
            int count = digits.Length > 0 ? int.Parse(digits) : 1;
            char letter = input[digits.Length];
            input = input[(digits.Length + 1)..];
            sb.Append(formatSequence(count, letter));
        }
        return sb.ToString();

    }
}
