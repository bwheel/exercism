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
        if(IsYellQuestion(statement))
            return "Calm down, I know what I'm doing!";
        
        if(AskedQuestion(statement))
            return "Sure.";
        
        if(IsYell(statement))
            return "Whoa, chill out!";
        
        if(OnlyAddressedWithGibberish(statement))
            return "Whatever.";
        else
            return "Fine. Be that way!";
    }

    private static bool AskedQuestion(string statement)
    {
        return Regex.Replace(statement, question_replacement_pattern, "").EndsWith("?");
    }

    private static bool IsYell(string statement)
    {
        var cleanedStatement = Regex.Replace(statement, yell_replacement_pattern, "");
        return cleanedStatement.ToUpper().EndsWith(cleanedStatement) && !String.IsNullOrWhiteSpace(cleanedStatement);
    }

    private static bool IsYellQuestion(string statement)
    {
        return AskedQuestion(statement) && IsYell(statement);
    }

    private static bool OnlyAddressedWithGibberish(string statement)
    {
        return !string.IsNullOrWhiteSpace(statement);
    }
}