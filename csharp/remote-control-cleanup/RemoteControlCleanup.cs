public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }

    public CarTelemetry Telemetry { get; set; }

    private Speed m_currentSpeed;
    public RemoteControlCar()
    {
        Telemetry = new CarTelemetry(this);
    }
    public string GetSpeed() => m_currentSpeed.ToString();

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;
    }

    private void SetSpeed(Speed speed)
    {
        m_currentSpeed = speed;
    }


    public class CarTelemetry
    {
        private RemoteControlCar m_car;
        internal CarTelemetry(RemoteControlCar car)
        { m_car = car; }
        public void Calibrate() { }
        public bool SelfTest() => true;
        public void ShowSponsor(string sponsorName)
        {
            m_car.SetSponsor(sponsorName);
        }
        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }
            m_car.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    internal enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    internal struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return $"{Amount} {unitsString}";
        }
    }

}