using System;
using System.Linq;
using System.Text;

public static class RotationalCipher
{
    private const string c_alphabetLowerCase = "abcdefghijklmnopqrstuvwxyz";
    private const string c_alphabetUpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string Rotate(string text, int shiftKey) =>
        string.Concat(text.Select(c => mapLetter(c, shiftKey)));

    private static char mapLetter(char input, int shiftKey) =>
        input switch
        {
            var u when char.IsUpper(u) => mapUpperLetter(input, shiftKey),
            var l when char.IsLower(l) => mapLowerLetter(input, shiftKey),
            _ => input,
        };

    private static char mapUpperLetter(char input, int shiftKey) =>
        c_alphabetUpperCase[calcNextIndex(c_alphabetUpperCase, input, shiftKey)];

    private static char mapLowerLetter(char input, int shiftKey) =>
            c_alphabetLowerCase[calcNextIndex(c_alphabetLowerCase, input, shiftKey)];
    private static int calcNextIndex(string alphabet, char input, int shiftKey) =>
        (alphabet.IndexOf(input) + shiftKey) % 26;

}