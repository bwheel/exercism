using System;
using System.Collections.Generic;
using System.Linq;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        var requiredClosingOrder = new Stack<char>();
        var preParsedInput = input.Where(letter => c_allKeyLetters.Contains(letter));
        foreach (var letter in preParsedInput)
        {
            if (c_openLetters.Contains(letter))
                requiredClosingOrder.Push(closingLetter(letter));
            else
            {
                if (!requiredClosingOrder.TryPeek(out char expected) || expected != letter)
                    return false;
                requiredClosingOrder.Pop();
            }
        }

        return !requiredClosingOrder.Any();
    }
    private const string c_openLetters = "({[";
    private const string c_allKeyLetters = c_openLetters + ")}]";

    private static char closingLetter(char letter)
        => letter switch
        {
            '(' => ')',
            '[' => ']',
            '{' => '}',
            _ => throw new ArgumentException(nameof(letter))
        };
}
