public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException();

        int sum = 0;

        for (int factor = 1; factor < number; factor++)
        {
            if (number % factor == 0)
                sum += factor;
        }

        return sum == number ? Classification.Perfect : 
            (sum > number ? Classification.Abundant : Classification.Deficient);
    }
}
