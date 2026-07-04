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
        List<DateTime> calendar = new();
                
        int day = 1;

        while (day <= DateTime.DaysInMonth(this.year, this.month))
        {
            calendar.Add(new DateTime(this.year, this.month, day));
            day++;
        }

        IEnumerable<DateTime> dates = calendar.Where(days => days.DayOfWeek == dayOfWeek);

        return schedule switch
        {
            Schedule.Teenth => dates.Single(date => date.Day >= 13 && date.Day <= 19),
            Schedule.First => dates.First(),
            Schedule.Second => dates.ElementAt(1),
            Schedule.Third => dates.ElementAt(2),
            Schedule.Fourth => dates.ElementAt(3),
            Schedule.Last => dates.Last(),
            _ => new()
        };
    }
}