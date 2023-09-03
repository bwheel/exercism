using System;

class RemoteControlCar
{
    private int distance = 0;
    private int battery = 100;

    public static RemoteControlCar Buy() => new();

    public string DistanceDisplay() => $"Driven {distance} meters";

    public string BatteryDisplay() => battery switch
    {
        <= 0 => "Battery empty",
        _ => $"Battery at {battery}%"
    };

    public void Drive()
    {
        if (battery <= 0)
            return;
        distance += 20;
        battery--;
    }
}
