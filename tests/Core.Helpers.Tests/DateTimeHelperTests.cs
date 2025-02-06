namespace Bieber.Core.Helpers.Tests;

public class DateTimeHelperTests
{
    [Fact]
    public void GetStartOfDay_ShouldReturnStartOfDay()
    {
        DateTime dateTime = new(2025, 1, 4, 13, 45, 30, DateTimeKind.Utc);
        DateOnly date = new(2025, 1, 4);

        DateTime result = DateTimeHelper.GetStartOfDay(dateTime);
        DateTime result2 = DateTimeHelper.GetStartOfDay(date);

        result.ShouldBe(new DateTime(2025, 1, 4, 0, 0, 0, DateTimeKind.Utc));
        result2.ShouldBe(new DateTime(2025, 1, 4, 0, 0, 0, DateTimeKind.Utc));
    }

    [Fact]
    public void GetEndOfDay_ShouldReturnEndOfDay()
    {
        DateTime dateTime = new(2025, 1, 4, 13, 45, 30, DateTimeKind.Utc);
        DateOnly date = new(2025, 1, 4);

        DateTime result = DateTimeHelper.GetEndOfDay(dateTime);
        DateTime result2 = DateTimeHelper.GetEndOfDay(date);

        result.ShouldBe(new DateTime(2025, 1, 4, 23, 59, 59, 999, DateTimeKind.Utc).AddTicks(9999));
        result2.ShouldBe(new DateTime(2025, 1, 4, 23, 59, 59, 999, DateTimeKind.Utc).AddTicks(9999));
    }

    [Fact]
    public void AddBusinessDays_ShouldReturnCorrectDate()
    {
        DateTime dateTime = new(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc); // Friday
        DateOnly date = new(2025, 1, 17); // Friday

        DateTime result = DateTimeHelper.AddBusinessDays(dateTime, 3);
        DateOnly result2 = DateTimeHelper.AddBusinessDays(date, 3);

        result.ShouldBe(new DateTime(2025, 1, 22, 0, 0, 0, DateTimeKind.Utc)); // Wednesday
        result2.ShouldBe(new DateOnly(2025, 1, 22)); // Wednesday
    }

    [Fact]
    public void Combine_ShouldReturnCombinedDateTime()
    {
        DateOnly date = new(2025, 1, 4);
        TimeOnly time = new(13, 45, 30);
        DateTime result = DateTimeHelper.Combine(date, time);
        result.ShouldBe(new DateTime(2025, 1, 4, 13, 45, 30, DateTimeKind.Utc));
    }

    [Fact]
    public void GetTime_ShouldReturnTimeOnly()
    {
        DateTime dateTime = new(2025, 1, 4, 13, 45, 30, DateTimeKind.Utc);
        TimeOnly result = DateTimeHelper.GetTime(dateTime);
        result.ShouldBe(new TimeOnly(13, 45, 30));
    }

    [Fact]
    public void IsWeekend_ShouldReturnTrue_WhenDateIsSaturdayOrSunday()
    {
        DateTime saturday = new(2025, 1, 4, 0, 0, 0, DateTimeKind.Utc);
        DateTime sunday = new(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc);
        DateTime monday = new(2025, 1, 6, 0, 0, 0, DateTimeKind.Utc);

        DateTimeHelper.IsWeekend(saturday).ShouldBeTrue();
        DateTimeHelper.IsWeekend(sunday).ShouldBeTrue();
        DateTimeHelper.IsWeekend(monday).ShouldBeFalse();
    }

    [Fact]
    public void IsWeekend_DateOnly_ShouldReturnTrue_WhenDateIsSaturdayOrSunday()
    {
        DateOnly saturday = new(2025, 1, 4);
        DateOnly sunday = new(2025, 1, 5);
        DateOnly monday = new(2025, 1, 6);

        DateTimeHelper.IsWeekend(saturday).ShouldBeTrue();
        DateTimeHelper.IsWeekend(sunday).ShouldBeTrue();
        DateTimeHelper.IsWeekend(monday).ShouldBeFalse();
    }

    [Fact]
    public void GetNextWeekday_ShouldReturnNextSpecifiedDayOfWeek()
    {
        DateTime start = new(2025, 1, 4, 0, 0, 0, DateTimeKind.Utc); // Saturday
        DateOnly start2 = new(2025, 1, 4); // Saturday

        DateTime result = DateTimeHelper.GetNextWeekday(start, DayOfWeek.Monday);
        DateOnly result2 = DateTimeHelper.GetNextWeekday(start2, DayOfWeek.Monday);

        result.ShouldBe(new DateTime(2025, 1, 6, 0, 0, 0, DateTimeKind.Utc)); // Monday
        result2.ShouldBe(new DateOnly(2025, 1, 6)); // Monday
    }

    [Fact]
    public void GetBusinessDaysBetween_ShouldReturnNumberOfBusinessDays()
    {
        DateTime start = new(2025, 1, 13, 0, 0, 0, DateTimeKind.Utc); // Monday
        DateTime end = new(2025, 1, 24, 0, 0, 0, DateTimeKind.Utc); // Friday
        DateOnly start2 = new(2025, 1, 13); // Monday
        DateOnly end2 = new(2025, 1, 24); // Friday

        int result = DateTimeHelper.GetBusinessDaysBetween(start, end);
        int result2 = DateTimeHelper.GetBusinessDaysBetween(start2, end2);

        result.ShouldBe(10);
        result2.ShouldBe(10);
    }

    [Fact]
    public void GetWeekendsBetween_ShouldReturnNumberOfWeekends()
    {
        DateTime start = new(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc); // Wednesday
        DateTime end = new(2025, 1, 31, 0, 0, 0, DateTimeKind.Utc); // Friday
        DateOnly start2 = new(2025, 1, 1); // Wednesday
        DateOnly end2 = new(2025, 1, 31); // Friday

        int result = DateTimeHelper.GetWeekendsBetween(start, end);
        int result2 = DateTimeHelper.GetWeekendsBetween(start2, end2);
        result.ShouldBe(4); // 5 weekends
        result2.ShouldBe(4); // 5 weekends
    }

    [Fact]
    public void CalculateAge_ShouldReturnCorrectAge()
    {
        DateTime dateOfBirth = new(1985, 12, 31, 0, 0, 0, DateTimeKind.Utc);
        DateTime referenceDate = new(2024, 12, 31, 0, 0, 0, DateTimeKind.Utc);
        DateOnly dateOfBirth2 = new(1985, 12, 31);
        DateOnly referenceDate2 = new(2024, 12, 31);

        int result = DateTimeHelper.CalculateAge(dateOfBirth, referenceDate);
        int result2 = DateTimeHelper.CalculateAge(dateOfBirth2, referenceDate2);

        result.ShouldBe(39);
        result2.ShouldBe(39);
    }

    [Fact]
    public void CalculateAge_ShouldReturnCorrectAge_WhenBirthdayNotYetOccurredThisYear()
    {
        DateTime dateOfBirth = new(1985, 12, 31, 0, 0, 0, DateTimeKind.Utc);
        DateTime referenceDate = new(2025, 2, 1, 0, 0, 0, DateTimeKind.Utc);
        DateOnly dateOfBirth2 = new(1985, 12, 31);
        DateOnly referenceDate2 = new(2025, 2, 1);

        int result = DateTimeHelper.CalculateAge(dateOfBirth, referenceDate);
        int result2 = DateTimeHelper.CalculateAge(dateOfBirth2, referenceDate2);

        result.ShouldBe(39);
        result2.ShouldBe(39);
    }
}
