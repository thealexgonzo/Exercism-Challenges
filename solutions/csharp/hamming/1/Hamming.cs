public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
            throw new ArgumentException();
        else if (firstStrand == secondStrand)
            return 0;
        else
        {
            int diffCount = 0;

            for (int i = 0; i < firstStrand.Length; i++)
            {
                if (firstStrand[i] != secondStrand[i])
                    ++diffCount;
            }

            return diffCount;
        }
    }
}