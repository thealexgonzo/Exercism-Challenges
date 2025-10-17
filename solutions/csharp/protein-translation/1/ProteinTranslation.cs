public static class ProteinTranslation
{
    private static readonly Dictionary<string, string> _proteins = new()
        {
            { "AUG", "Methionine" },
            { "UUU,UUC", "Phenylalanine" },
            { "UUA,UUG", "Leucine" },
            { "UCU,UCC,UCA,UCG", "Serine" },
            { "UAU,UAC", "Tyrosine" },
            { "UGU,UGC", "Cysteine" },
            { "UGG", "Tryptophan" }
        };

    private static readonly string _STOP = "UAA,UAG,UGA";

    public static string[] Proteins(string strand)
    {
        if (string.IsNullOrEmpty(strand))
            return [];

        List<string> proteinsFound = new();

        for (int i = 0; i < strand.Length; i+=3)
        {
            string codon = strand.Substring(i, 3);

            if (_STOP.Contains(codon))
                break;

            foreach (string protein in _proteins.Keys)
            {
                if (protein.Contains(codon))
                    proteinsFound.Add(_proteins[protein]);
            }
        }

        return proteinsFound.ToArray();
    }
}