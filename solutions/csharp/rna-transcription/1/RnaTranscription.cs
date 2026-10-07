using System.Reflection.Metadata.Ecma335;

public static class RnaTranscription
{
    private static Dictionary<char, char> nucleotideComplements = new()
    {
        { 'G', 'C' },
        { 'C', 'G' },
        { 'T', 'A' },
        { 'A', 'U' }
    };

    public static string ToRna(string strand)
    {
        if (string.IsNullOrEmpty(strand))
            return string.Empty;

        string transcribedStrand = "";

        foreach (char s in strand)
        {
            transcribedStrand += nucleotideComplements[s];
        }

        return transcribedStrand;
    }
}