using System;
using System.Linq;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay) => this.birdsPerDay = birdsPerDay;

    public static int[] LastWeek() => new int[] { 0, 2, 5, 3, 7, 8, 4 };
    public int Today() => birdsPerDay.Last();

    public void IncrementTodaysCount() => birdsPerDay[^1]++;

    public bool HasDayWithoutBirds() => birdsPerDay.Where(c => c == 0).Any();

    public int CountForFirstDays(int numberOfDays) => birdsPerDay.Take(numberOfDays).Sum();

    public int BusyDays() => birdsPerDay.Where(c => c >= 5).Count();
}
