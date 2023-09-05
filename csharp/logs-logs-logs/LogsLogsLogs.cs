using System;
using System.Text.RegularExpressions;


public enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
};

static class LogLine
{
    private const string pattern = @"\[(.+)\]: .*";

    public static LogLevel parseText(string text)
        => text switch
        {
            "TRC" => LogLevel.Trace,
            "DBG" => LogLevel.Debug,
            "INF" => LogLevel.Info,
            "WRN" => LogLevel.Warning,
            "ERR" => LogLevel.Error,
            "FTL" => LogLevel.Fatal,
            _ => LogLevel.Unknown,

        };

    private static LogLevel parseRegExMatch(Match match)
        => match.Success
            ? parseText(match.Groups[1].Value)
            : LogLevel.Unknown;

    public static LogLevel ParseLogLevel(string logLine)
        => parseRegExMatch(Regex.Match(logLine, pattern));

    public static string OutputForShortLog(LogLevel logLevel, string message)
        => $"{(int)logLevel}:{message}";
}
