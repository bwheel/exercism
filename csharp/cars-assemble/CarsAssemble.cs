using System;

static class AssemblyLine
{
    public static double SuccessRate(int speed)
        => speed switch
        {
            0 => 0,
            int s when s >= 1 && s <= 4 => 1,
            int s when s >= 5 && s <= 8 => .9,
            9 => .8,
            10 => .77,
            _ => throw new ArgumentException("Invalid speed value", nameof(speed)),
        };
    public static double ProductionRatePerHour(int speed) => speed * SuccessRate(speed) * 221.0;
    public static int WorkingItemsPerMinute(int speed) => (int)ProductionRatePerHour(speed) / 60;
}
