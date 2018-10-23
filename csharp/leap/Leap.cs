using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        return year.IsDivisibleBy400() ||
                (year.IsDivisibleBy4() && !year.IsDivisibleBy100());
        
    }
}
static class LeapExtensions
{
    public static bool IsDivisibleBy4(this int year)
    {
        return year % 4 == 0;
    }

    public static bool IsDivisibleBy100(this int year)
    {
        return year % 100 == 0;
    }

    public static bool IsDivisibleBy400(this int year)
    {
        return year % 400 == 0;
    }
}