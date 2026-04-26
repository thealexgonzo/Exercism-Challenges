using System.Data;

public static class Transpose
{
    public static string String(string input)
    {

        if (string.IsNullOrWhiteSpace(input)) return string.Empty;
        if (!input.Contains('\n')) return string.Join('\n', input.ToCharArray());

        string[] rows = input.Split('\n');

        int longestRowLength = rows.Max(r => r.Length);
        string[] transposed = new string[longestRowLength];

        for (int row = 0; row < rows.Length; row++)
        {
            for (int rowIndex = 0; rowIndex < longestRowLength; rowIndex++)
            {
                transposed[rowIndex] += rowIndex >= rows[row].Length
                    ? (rows.Skip(row).Any(r => r.Length > rowIndex) 
                        ? " " 
                        : "") 
                    : rows[row][rowIndex];
            }
        }
         
        return string.Join('\n', transposed);
    }
}