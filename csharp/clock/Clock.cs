using System;

public class Clock : IEquatable<Clock>
{
    public Clock(int hours, int minutes)
    {
        // keep track of the additional hours from the overflow minutes.
        int hoursFromMinutes = minutes / 60;

        // reduce minutes to base 60 (-60 < m < +60).
        minutes = (minutes > 0) ? minutes % 60 : -1 * (Math.Abs(minutes) % 60);
        
        // take into account negative minutes
        this.Minutes = (minutes < 0) ? 60 + minutes: minutes;

        // add up the total hours, before reducing to base 24.
        hours = (minutes < 0) ?  hours + hoursFromMinutes - 1 :  hours + hoursFromMinutes;

		// reduce to base 24 (outside the daily window -24 < h < +24).
        hours = (hours > 0) ? hours % 24 : -1 * (Math.Abs(hours) % 24);

        // take into accoutn negative hours
        this.Hours = (hours < 0) ? 24 + hours : hours;
    }

    public int Hours { get; }

    public int Minutes { get; }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(this.Hours, this.Minutes + minutesToAdd);
    }

    public bool Equals(Clock other)
    {
        return other != null && this.Hours == other.Hours && this.Minutes == other.Minutes;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return this.Add(minutesToSubtract * -1);
    }

    public override string ToString()
    {
        return $"{Hours:00}:{Minutes:00}";
    }
}