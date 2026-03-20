
public static class Acronym
{
    public static string Abbreviate(string phrase) => 
        new string(
            phrase
                .Replace('-', ' ')
                .Replace('_', ' ')
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(word => char.ToUpper(word[0]))
                .ToArray()
            );    
}