public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> nucleotideCount = new()
        {
            { 'A', 0 },
            { 'C', 0 },
            { 'G', 0 },
            { 'T', 0 }
        };

        if (sequence.Any(s => !nucleotideCount.Keys.Contains(s)))
            throw new ArgumentException();

        foreach (char nucleotide in sequence)
            if (nucleotideCount.Keys.Any(nck => nck == nucleotide))
                nucleotideCount[nucleotide] += 1;        

        return nucleotideCount;
    }
}