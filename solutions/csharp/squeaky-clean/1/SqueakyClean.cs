using System.Globalization;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder cleanIdentifier = new();

        for (int i = 0; i < identifier.Length; i++)
        {
            if (char.IsControl(identifier[i])) cleanIdentifier.Append("CTRL");
            else if (identifier[i] == ' ') cleanIdentifier.Append('_');
            else if (char.IsDigit(identifier[i]) || !char.IsLetter(identifier[i])) continue;
            else if ("αβγδεζηθικλμνξοπρστυφχψω".Contains(identifier[i])) continue;
            else if (identifier[i] == '-') continue;
            else if (i > 0 && identifier[i - 1] == '-') cleanIdentifier.Append(char.ToUpper(identifier[i]));            
            else cleanIdentifier.Append(identifier[i]);
        }

        return cleanIdentifier.ToString();
    }
}
