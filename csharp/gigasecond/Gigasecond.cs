using System;

public static class Gigasecond
{
    private const double seconds = 1e9;
    public static DateTime Add(DateTime moment)
    {
        return moment.AddSeconds(seconds);
    }
}