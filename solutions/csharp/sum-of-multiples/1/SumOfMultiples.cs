using System.Diagnostics.Metrics;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        if (multiples.Count() == 0)
            return 0;

        HashSet<int> baseValues = new();

        foreach(var value in multiples)
        {
            for (int counter = 1; value * counter < max && value != 0; counter++)
            {
                baseValues.Add(value * counter);
            }
        }

        return baseValues.Sum();
    }
}