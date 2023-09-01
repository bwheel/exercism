using System;
using System.Diagnostics;
using System.Linq;
using Xunit.Sdk;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string source, string delimeter)
        => source.Split(delimeter)[1];
    public static string SubstringBetween(this string source, string before, string after)
        =>source.SubstringAfter(before).Split(after)[0];
    public static string Message(this string log)
        => log.SubstringAfter(": ");
    public static string LogLevel(this string log)
        => log.SubstringBetween("[","]");
}