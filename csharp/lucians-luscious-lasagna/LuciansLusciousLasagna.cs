class Lasagna
{
    public int ExpectedMinutesInOven() => 40;
    public int RemainingMinutesInOven(int current) => ExpectedMinutesInOven() - current;
    public int PreparationTimeInMinutes(int layers) => layers * 2;
    public int ElapsedTimeInMinutes(int layers, int minutesBaked) => PreparationTimeInMinutes(layers) + minutesBaked;
}
