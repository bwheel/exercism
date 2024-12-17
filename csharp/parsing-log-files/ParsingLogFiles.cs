using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text) =>
        s_isValidLinePattern.IsMatch(text);

    public string[] SplitLogLine(string text) =>
        s_splitLogLineRegex.Split(text);

    public int CountQuotedPasswords(string lines) =>
        s_countQuotedPasswordsRegex.Count(lines);

    public string RemoveEndOfLineText(string line) =>
        s_removeEndOfLineRegex.Replace(line, string.Empty);

    public string[] ListLinesWithPasswords(string[] lines) =>
        listLinesWithPasswordsInternal(lines).ToArray();
    private IEnumerable<string> listLinesWithPasswordsInternal(string[] lines)
    {
        foreach (var line in lines)
        {
            var match = s_listLinesWithPasswordsRegex.Match(line);
            if (match != Match.Empty)
                yield return $"{match.Value}: {line}";
            else
                yield return $"--------: {line}";
        }
    }

    private static readonly Regex s_isValidLinePattern = new Regex(c_isValidLinePattern, RegexOptions.Compiled);
    private static readonly Regex s_splitLogLineRegex = new Regex(c_splitLogLinePattern, RegexOptions.Compiled);
    private static readonly Regex s_countQuotedPasswordsRegex = new Regex(c_countQuotedPasswordsPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly Regex s_removeEndOfLineRegex = new Regex(c_removeEndOfLineTextPattern, RegexOptions.Compiled);
    private static readonly Regex s_listLinesWithPasswordsRegex = new Regex(c_listLinesWithPasswordsInternalPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private const string c_isValidLinePattern = @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
    private const string c_splitLogLinePattern = @"<[\^*-=]+>";
    private const string c_countQuotedPasswordsPattern = @""".*password.*""";
    private const string c_removeEndOfLineTextPattern = @"end-of-line\d+";
    private const string c_listLinesWithPasswordsInternalPattern = @"password\w+";
}
