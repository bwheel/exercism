using System;
using System.Text.RegularExpressions;
public static class Bob
{
    private const string punctuation_pattern = @"\p{P}";
    private const string numbers_pattern = @"0-9";
    private const string whitespace_pattern = @"\s";
    private static string question_replacement_pattern = $"([{whitespace_pattern}{numbers_pattern}]+)";
    private static string yell_replacement_pattern = $"([{whitespace_pattern}{numbers_pattern}{punctuation_pattern}]+)";
    public static string Response(string statement)
    {
        if(isYellQuestion(statement))
        {
            return "Calm down, I know what I'm doing!";
        }
        else if(askedQuestion(statement))
        {
            return "Sure.";
        }
        else if(isYell(statement))
        {
            return "Whoa, chill out!";
        }
        else if(onlyAddressedWithGibberish(statement))
        {
            return "Whatever.";
        }
        else
        {
            return "Fine. Be that way!";
        }
    }

    private static bool askedQuestion(string statement)
    {
        return Regex.Replace(statement, question_replacement_pattern, "").EndsWith("?");
    }

    private static bool isYell(string statement)
    {
        var cleanedStatement = Regex.Replace(statement, yell_replacement_pattern, "");
        return cleanedStatement.ToUpper().EndsWith(cleanedStatement) && !String.IsNullOrWhiteSpace(cleanedStatement);
    }

    private static bool isYellQuestion(string statement)
    {
        return askedQuestion(statement) && isYell(statement);
    }

    private static bool onlyAddressedWithGibberish(string statement)
    {
        return !String.IsNullOrWhiteSpace(statement);
    }
}