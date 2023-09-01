using System;

static class LogLine
{
    public static string Message(string logLine)
        => logLine
            .Trim()
            .Replace("[ERROR]: ","")
            .Replace("[WARNING]: ", "")
            .Replace("[INFO]: ", "")
            .Trim();

    public static string LogLevel(string logLine)
        => logLine.Trim() switch
            {
                string s when s.StartsWith("[INFO]") => "info",
                string s when s.StartsWith("[WARNING]") => "warning",
                string s when s.StartsWith("[ERROR]") => "error",
                _ => throw new ArgumentException("Invalid loglevel", nameof(logLine)),
            };

    public static string Reformat(string logLine)
        => $"{Message(logLine)} ({LogLevel(logLine)})";
}
