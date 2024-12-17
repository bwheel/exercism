using System;

public class SpaceAge
{
    private const double c_earthYearInSeconds = 31_557_600.0;
    private int m_seconds;
    public SpaceAge(int seconds) => m_seconds = seconds;

    public double OnEarth() => m_seconds / c_earthYearInSeconds;

    public double OnMercury() => m_seconds / (c_earthYearInSeconds * 0.2408467);

    public double OnVenus() => m_seconds / (c_earthYearInSeconds * 0.61519726);

    public double OnMars() => m_seconds / (c_earthYearInSeconds * 1.8808158);

    public double OnJupiter() => m_seconds / (c_earthYearInSeconds * 11.862615);

    public double OnSaturn() => m_seconds / (c_earthYearInSeconds * 29.447498);

    public double OnUranus() => m_seconds / (c_earthYearInSeconds * 84.016846);

    public double OnNeptune() => m_seconds / (c_earthYearInSeconds * 164.79132);
}