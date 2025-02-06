namespace Bieber.Core.Helpers;

/// <summary>
/// Provides helper methods for DateTime, DateOnly, and TimeOnly manipulation.
/// </summary>
public static class DateTimeHelper
{
    /// <summary>
    /// Gets the start of the day for a given date.
    /// </summary>
    /// <param name="date">The date for which to get the start of the day.</param>
    /// <returns>A DateTime representing the start of the day.</returns>
    public static DateTime GetStartOfDay(DateTime date)
    {
        return date.Date;
    }

    /// <summary>
    /// Gets the start of the day for a given DateOnly.
    /// </summary>
    /// <param name="date">The DateOnly for which to get the start of the day.</param>
    /// <returns>A DateTime representing the start of the day.</returns>
    public static DateTime GetStartOfDay(DateOnly date)
    {
        return date.ToDateTime(TimeOnly.MinValue);
    }

    /// <summary>
    /// Gets the end of the day for a given date.
    /// </summary>
    /// <param name="date">The date for which to get the end of the day.</param>
    /// <returns>A DateTime representing the end of the day.</returns>
    public static DateTime GetEndOfDay(DateTime date)
    {
        return DateTime.SpecifyKind(date.Date.AddDays(1).AddTicks(-1), date.Kind);
    }

    /// <summary>
    /// Gets the end of the day for a given DateOnly.
    /// </summary>
    /// <param name="date">The DateOnly for which to get the end of the day.</param>
    /// <returns>A DateTime representing the end of the day.</returns>
    public static DateTime GetEndOfDay(DateOnly date)
    {
        return date.ToDateTime(TimeOnly.MaxValue);
    }


    /// <summary>
    /// Adds the specified number of business days to a date.
    /// </summary>
    /// <param name="date">The date to which to add business days.</param>
    /// <param name="days">The number of business days to add.</param>
    /// <returns>The DateTime that results from adding the specified number of business days.</returns>
    public static DateTime AddBusinessDays(DateTime date, int days)
    {
        DateTimeKind kind = date.Kind;
        int addedDays = 0;
        while (addedDays < days)
        {
            date = date.AddDays(1);
            if (date.DayOfWeek is not DayOfWeek.Saturday and not DayOfWeek.Sunday)
            {
                addedDays++;
            }
        }
        return DateTime.SpecifyKind(date, kind);
    }

    /// <summary>
    /// Adds the specified number of business days to a DateOnly.
    /// </summary>
    /// <param name="date">The DateOnly to which to add business days.</param>
    /// <param name="days">The number of business days to add.</param>
    /// <returns>The DateOnly that results from adding the specified number of business days.</returns>
    public static DateOnly AddBusinessDays(DateOnly date, int days)
    {
        int addedDays = 0;
        while (addedDays < days)
        {
            date = date.AddDays(1);
            if (date.DayOfWeek is not DayOfWeek.Saturday and not DayOfWeek.Sunday)
            {
                addedDays++;
            }
        }
        return date;
    }

    /// <summary>
    /// Combines a DateOnly and a TimeOnly into a DateTime.
    /// </summary>
    /// <param name="date">The DateOnly.</param>
    /// <param name="time">The TimeOnly.</param>
    /// <param name="kind">The DateTimeKind to be set for the result.</param>
    /// <returns>A DateTime representing the combined date and time.</returns>
    public static DateTime Combine(DateOnly date, TimeOnly time, DateTimeKind kind = DateTimeKind.Utc)
    {
        return date.ToDateTime(time, kind);
    }

    /// <summary>
    /// Gets the TimeOnly portion of a DateTime.
    /// </summary>
    /// <param name="dateTime">The DateTime.</param>
    /// <returns>The TimeOnly portion of the DateTime.</returns>
    public static TimeOnly GetTime(DateTime dateTime)
    {
        return TimeOnly.FromDateTime(dateTime);
    }

    /// <summary>
    /// Checks if a given date falls on a weekend.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <returns>true if the date is a Saturday or Sunday; otherwise, false.</returns>
    public static bool IsWeekend(DateTime date)
    {
        return date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
    }

    /// <summary>
    /// Checks if a given DateOnly falls on a weekend.
    /// </summary>
    /// <param name="date">The DateOnly to check.</param>
    /// <returns>true if the DateOnly is a Saturday or Sunday; otherwise, false.</returns>
    public static bool IsWeekend(DateOnly date)
    {
        return date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
    }

    /// <summary>
    /// Gets the next occurrence of a specific day of the week.
    /// </summary>
    /// <param name="start">The start date.</param>
    /// <param name="dayOfWeek">The day of the week to find.</param>
    /// <returns>The next occurrence of the specified day of the week.</returns>
    public static DateTime GetNextWeekday(DateTime start, DayOfWeek dayOfWeek)
    {
        int daysToAdd = ((int)dayOfWeek - (int)start.DayOfWeek + 7) % 7;
        return start.AddDays(daysToAdd == 0 ? 7 : daysToAdd);
    }

    /// <summary>
    /// Gets the next occurrence of a specific day of the week.
    /// </summary>
    /// <param name="start">The start date.</param>
    /// <param name="dayOfWeek">The day of the week to find.</param>
    /// <returns>The next occurrence of the specified day of the week.</returns>
    public static DateOnly GetNextWeekday(DateOnly start, DayOfWeek dayOfWeek)
    {
        int daysToAdd = ((int)dayOfWeek - (int)start.DayOfWeek + 7) % 7;
        return start.AddDays(daysToAdd == 0 ? 7 : daysToAdd);
    }

    /// <summary>
    /// Gets the number of business days between two dates.
    /// </summary>
    /// <param name="start">The start date.</param>
    /// <param name="end">The end date.</param>
    /// <returns>The number of business days between the start and end dates.</returns>
    public static int GetBusinessDaysBetween(DateTime start, DateTime end)
    {
        int businessDays = 0;
        DateTime current = start.Date;
        end = end.Date;

        while (current <= end)
        {
            if (current.DayOfWeek is not DayOfWeek.Saturday and not DayOfWeek.Sunday)
            {
                businessDays++;
            }
            current = current.AddDays(1);
        }

        return businessDays;
    }
    /// <summary>
    /// Gets the number of business days between two dates.
    /// </summary>
    /// <param name="start">The start date.</param>
    /// <param name="end">The end date.</param>
    /// <returns>The number of business days between the start and end dates.</returns>
    public static int GetBusinessDaysBetween(DateOnly start, DateOnly end) =>
        GetBusinessDaysBetween(start.ToDateTime(TimeOnly.MinValue), end.ToDateTime(TimeOnly.MinValue));

    /// <summary>
    /// Gets the number of weekends between two dates.
    /// </summary>
    /// <param name="start">The start date.</param>
    /// <param name="end">The end date.</param>
    /// <returns>The number of weekends between the start and end dates.</returns>
    public static int GetWeekendsBetween(DateTime start, DateTime end)
    {
        int weekends = 0;
        DateTime current = start.Date;
        end = end.Date;

        while (current <= end)
        {
            if (current.DayOfWeek == DayOfWeek.Saturday)
            {
                weekends++;
                current = current.AddDays(2);
            }
            else
            {
                if (current.DayOfWeek == DayOfWeek.Sunday)
                {
                    weekends++;
                }
                current = current.AddDays(1);
            }
        }

        return weekends;
    }

    /// <summary>
    /// Gets the number of weekends between two dates.
    /// </summary>
    /// <param name="start">The start date.</param>
    /// <param name="end">The end date.</param>
    /// <returns>The number of weekends between the start and end dates.</returns>
    public static int GetWeekendsBetween(DateOnly start, DateOnly end) =>
        GetWeekendsBetween(start.ToDateTime(TimeOnly.MinValue), end.ToDateTime(TimeOnly.MinValue));

    /// <summary>
    /// Calculates the age based on a given date of birth.
    /// </summary>
    /// <param name="dateOfBirth">The date of birth.</param>
    /// <param name="referenceDate">The reference date to calculate the age from. Defaults to today.</param>
    /// <returns>The age in years.</returns>
    public static int CalculateAge(DateTime dateOfBirth, DateTime? referenceDate = null)
    {
        DateTime today = referenceDate ?? DateTime.Today;
        int age = today.Year - dateOfBirth.Year;

        if (dateOfBirth > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }
    /// <summary>
    /// Calculates the age based on a given date of birth.
    /// </summary>
    /// <param name="dateOfBirth">The date of birth.</param>
    /// <param name="referenceDate">The reference date to calculate the age from. Defaults to today.</param>
    /// <returns>The age in years.</returns>
    public static int CalculateAge(DateOnly dateOfBirth, DateOnly? referenceDate = null) =>
        CalculateAge(dateOfBirth.ToDateTime(TimeOnly.MinValue), referenceDate?.ToDateTime(TimeOnly.MinValue));
}
