public static class Bob
{
    public static string Response(string statement)
    {
        if (string.IsNullOrWhiteSpace(statement))
        {
            return "Fine. Be that way!";
        }

        List<char> letter = new();

        foreach (char character in statement)
        {
            if (char.IsLetter(character))
                letter.Add(character);
        }
        
        if (statement.Trim().EndsWith('?'))
        {
            if (letter.All(char.IsUpper) && letter.Count > 0)
            {
                return "Calm down, I know what I'm doing!";
            }
            else
            {
                return "Sure.";
            }
        }
        else
        {
            if (letter.All(char.IsUpper) && letter.Count > 0)
            {
                return "Whoa, chill out!";
            }
            else
            {
                return "Whatever.";
            }
        }
    }
}