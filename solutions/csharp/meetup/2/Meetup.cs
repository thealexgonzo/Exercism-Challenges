using System.Data;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly int month;
    private readonly int year;

    public Meetup(int month, int year)
    {
        this.month = month;
        this.year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        IEnumerable<DateTime> dates = Enumerable.Range(1, DateTime.DaysInMonth(this.year, this.month))
                                                .Select(day => new DateTime(this.year, this.month, day))
                                                .Where(days => days.DayOfWeek == dayOfWeek);

        return schedule switch
        {
            Schedule.Teenth => dates.Single(date => date.Day is >= 13 and <= 19),
            Schedule.First => dates.First(),
            Schedule.Second => dates.ElementAt(1),
            Schedule.Third => dates.ElementAt(2),
            Schedule.Fourth => dates.ElementAt(3),
            Schedule.Last => dates.Last(),
            _ => throw new ArgumentOutOfRangeException(nameof(schedule))
        };
    }
}