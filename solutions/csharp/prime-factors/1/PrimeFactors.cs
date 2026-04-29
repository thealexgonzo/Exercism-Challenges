public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        List<long> output = new();

        for (int i = 0; i <= number; i++)
        {
            if(IsPrime(i))
            {
                while(number % i == 0)
                {
                    output.Add(i);
                    number /= i;
                }
            }
        }

        return output.ToArray();
    }

    private static bool IsPrime(int number)
    {
        int temp = number;
        int[] numEndsIn = { 0, 2, 4, 5, 6, 8};
        int sum = 0;
        
        if(number > 10)
        {
            while (temp > 0)
            {
                sum += temp % 10;
                temp /= 10;
            }
        }
        
        if (number < 2) return false;
        else if (number is 2 || number is 3 || number is 5) return true;
        else if (numEndsIn.Contains(number % 10)) return false;
        else if (sum % 3 is 0) return false;
        else return true;
    }
}