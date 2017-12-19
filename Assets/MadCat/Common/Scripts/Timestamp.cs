using System;

public static class Timestamp
{
    static DateTime EpochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

    public static int ToDayStamp(this DateTime time)
    {
        return time.Year * 10000 + time.Month * 100 + time.Day;
    }

    public static int ToTimeStamp(this DateTime time)
    {
        if (time.Kind != DateTimeKind.Utc)
        {
            time = time.ToUniversalTime();
        }
        return (int)(time - EpochStart).TotalSeconds;
    }

    public static DateTime ToUtcDateTime(double timestamp)
    {
        return EpochStart.AddSeconds(timestamp);
    }

    public static DateTime ToLocalDateTime(double timestamp)
    {
        return ToUtcDateTime(timestamp).ToLocalTime();
    }
}
