using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

public class TimeZoneAttribute : System.Attribute
{
    public required string OSX { get; set; }
    public required string Linux { get; set; }
    public required string Windows { get; set; }
    private string timeZoneId => RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        ? Windows
        : RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
            ? OSX
            : Linux;
    public TimeZoneInfo TimeZoneInfo => TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
}

public static class LocationExtension
{
    public static CultureInfo GetCultureInfo(this Location location) =>
            location switch
            {
                Location.NewYork => CultureInfo.GetCultureInfo("en-US"),
                Location.London => CultureInfo.GetCultureInfo("en-GB"),
                Location.Paris => CultureInfo.GetCultureInfo("fr-FR"),
                _ => throw new ArgumentOutOfRangeException(nameof(location)),
            };
    public static TimeZoneInfo GetTimeZoneInfo(this Location location) =>
        location
        .GetType()
        .GetMember(location.ToString())
        .First()
        .GetCustomAttribute<TimeZoneAttribute>()!
        .TimeZoneInfo;
}

public enum Location
{
    [TimeZone(Linux = "America/New_York", OSX = "America/New_York", Windows = "Eastern Standard Time")]
    NewYork,
    [TimeZone(Linux = "Europe/London", OSX = "Europe/London", Windows = "GMT Standard Time")]
    London,
    [TimeZone(Linux = "Europe/Paris", OSX = "Europe/Paris", Windows = "W. Europe Standard Time")]
    Paris
}

public static class AlertLevelExtension
{
    public static TimeSpan GetDuration(this AlertLevel alertLevel) =>
    alertLevel switch
    {
        AlertLevel.Early => TimeSpan.FromDays(1),
        AlertLevel.Standard => TimeSpan.FromMinutes(60 + 45),
        AlertLevel.Late => TimeSpan.FromMinutes(30),
        _ => throw new ArgumentException(nameof(alertLevel)),
    };
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}



public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) =>
        dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var dt = DateTime.Parse(appointmentDateDescription);
        var result = dt.Subtract(location.GetTimeZoneInfo().GetUtcOffset(dt));
        return result;
    }


    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) =>
        appointment.Subtract(alertLevel.GetDuration());

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var tzi = location.GetTimeZoneInfo();
        return tzi.IsDaylightSavingTime(dt) != tzi.IsDaylightSavingTime(dt.AddDays(-7));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location loc)
    {
        var cultureInfo = loc.GetCultureInfo();
        var isSuccess = DateTime.TryParse(dtStr, cultureInfo, out var dateTime);
        return isSuccess ? dateTime : DateTime.MinValue;
    }
}
