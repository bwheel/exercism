using System;

public class Clock
{
    private int totalMinutes;
    public int Hours 
    {
        get
        {
            int hours = totalMinutes / 60;
            hours = hours % 24;

            if (hours < 0)
            {
                hours = 24 + hours;
            }
            else if (hours == 0)
            {
                if(totalMinutes<0)
                {
                    hours = 23;
                }
                else
                {
                    hours = 0;
                }
            }
            return hours;
        }
    }
    public int Minutes 
    {
        get
        {
            int minutes = totalMinutes % 60;

            return minutes < 0 ? minutes + 60 : minutes;
        }
    } 

    public Clock(int hours, int minutes)
    {
        totalMinutes = minutes + (hours*60);
    }

    public Clock Add(int minutesToAdd)
    {
        totalMinutes += minutesToAdd;
        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        totalMinutes -= minutesToSubtract;
        return this;
    }

    public override string ToString()
    {
        return $"{this.Hours.ToString().PadLeft(2, '0')}:{this.Minutes.ToString().PadLeft(2, '0')}";
    }
}