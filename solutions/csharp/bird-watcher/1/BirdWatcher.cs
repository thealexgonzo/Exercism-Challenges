using Xunit.Runner.Common;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return [0, 2, 5, 3, 7, 8, 4];
    }

    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        for(int i = 0; i < birdsPerDay.Length; i++)
        {
            if (birdsPerDay[i] == 0)
                return true;
        }

        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int result = 0;

        for(int i = 0; i < numberOfDays; i++)
        {
            result += birdsPerDay[i];
        }

        return result;
    }

    public int BusyDays()
    {
        int counter = 0;

        for(int i = 0; i < birdsPerDay.Length; i++)
        {
            if (birdsPerDay[i] >= 5)
                counter++;
        }

        return counter;
    }
}
