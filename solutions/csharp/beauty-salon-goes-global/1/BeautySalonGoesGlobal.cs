using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    private static string GetTimeZoneID(Location location)
    {
        bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        return location switch
        {
            Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
            Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
            Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe / Paris",
            _ => ""
        };
    }

    public static DateTime ShowLocalTime(DateTime dtUtc) => 
        TimeZoneInfo.ConvertTimeFromUtc(dtUtc, TimeZoneInfo.Local);    

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime parsedDateTime = DateTime.Parse(appointmentDateDescription);        
        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneID(location));
        return TimeZoneInfo.ConvertTimeToUtc(parsedDateTime, timeZone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) => alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Late => appointment.AddMinutes(-30),
            AlertLevel.Standard => appointment.AddHours(-1.75),
            _ => appointment
        };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneID(location));
        return timeZone.IsDaylightSavingTime(dt) != timeZone.IsDaylightSavingTime(dt.AddDays(-7));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        string format = location switch
        {
            Location.NewYork => "MM/dd/yyyy HH:mm:ss",
            Location.London => "dd/MM/yyyy HH:mm:ss",
            Location.Paris => "dd/MM/yyyy HH:mm:ss",
            _ => throw new ArgumentOutOfRangeException(nameof(location))
        };

        if (DateTime.TryParseExact(dtStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime))
        {
            return parsedDateTime;
        }

        //if (DateTime.TryParseExact(
        //dtStr,
        //format,
        //CultureInfo.InvariantCulture,
        //DateTimeStyles.None,
        //out DateTime parsedDateTime))
        //{
        //    return parsedDateTime;
        //}

        return DateTime.MinValue;
    }
}
