using System;

class RemoteControlCar
{
    private int _battery = 100;
    private int _distance = 0;
    private int _speed;
    private int _batteryDrain;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => _battery < _batteryDrain;

    public int DistanceDriven() => _distance;

    public void Drive()
    {
        if (!BatteryDrained())
        {
            _distance += _speed;
            _battery -= _batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int _distance;


    public RaceTrack(int distance) => _distance = distance;

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained() && car.DistanceDriven() < _distance)
        {
            car.Drive();
        }
        return car.DistanceDriven() >= _distance;
    }
}
