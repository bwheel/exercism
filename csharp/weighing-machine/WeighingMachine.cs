using System;

class WeighingMachine(int precision)
{
    public int Precision { get; } = precision;

    private double weight;
    public double Weight
    {
        get => weight;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            weight = value;
        }
    }
    public string DisplayWeight
        => $"{(Weight - TareAdjustment).ToString($"N{Precision}")} kg";

    public double TareAdjustment { get; set; } = 5.0;
}
