using System;

public class Clock : IEquatable<Clock>
{
    public Clock(int hours, int minutes)
    {
        int hoursFromMinutes = 0;
        if(minutes > 0)
        {
            while(minutes >= 60)
            {
                hoursFromMinutes ++;
                minutes -= 60;
            }
        }
        else
        {
            while(minutes <= -60)
            {
                hoursFromMinutes--;
                minutes += 60;
            }
        }
        Minutes = (minutes < 0) ? 60 + minutes: minutes;

        hours = (minutes < 0) ?  hours + hoursFromMinutes - 1 :  hours + hoursFromMinutes;
		
        if(hours > 0)
        {
            while(hours >= 24)
            {
                hours-=24;
            }
        }
        else
        {
            while(hours <= -24)
            {
                hours += 24;
            }
        }
        Hours = (hours < 0) ? 24 + hours : hours;
    }

    public int Hours { get; private set; }

    public int Minutes { get; private set; }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(Hours, Minutes + minutesToAdd);
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
        return $"{Hours.ToString("00")}:{Minutes.ToString("00")}";
    }
}