using System;
using System.Text;

public static class Identifier2
{
    public static string Clean(string identifier)
    {
        StringBuilder sb = new StringBuilder();
        int index = 0;

        while (index < identifier.Length)
        {
            char c = identifier[index];
            string nextChar = c switch
            {
                ' ' => "_",
                '-' => index + 1 < identifier.Length ? Char.ToUpper(identifier[++index]).ToString() : "",
                char l when Char.IsControl(l) => "CTRL",
                char l when IsGreekLetter(l) => "",
                char l when Char.IsLetter(l) => l.ToString(),
                _ => "",
            };

            sb.Append(nextChar);
            index++; // Increment index to avoid infinite loop
        }

        return sb.ToString();
    }

    private static bool IsGreekLetter(char c) => (c >= 'α' && c <= 'ω');
}
