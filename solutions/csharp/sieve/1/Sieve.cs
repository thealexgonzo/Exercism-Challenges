
public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2) 
            return new int[0];

        Dictionary<int, char> numbers = new();

        for (int i = 2; i <= limit; i++)
        {
            if (!numbers.ContainsKey(i))
            {
                numbers[i] = 'P';

                for (int n = i; n <= limit; n++)
                {
                    int multiple = i * n;

                    if (n > limit / 2)
                        break;

                    numbers[multiple] = ' ';
                }
            }
        }

        return numbers.Where(number => number.Value == 'P')
                      .Select(number => number.Key)
                      .ToArray();
    }
}


