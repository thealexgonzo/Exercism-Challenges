public static class Bob
{
    public static string Response(string statement)
    {
        if (string.IsNullOrWhiteSpace(statement))
        {
            return "Fine. Be that way!";
        }
        else if (statement.TrimEnd().EndsWith('?'))
        {
            if (statement.Any(char.IsLetter) && statement.ToUpper() == statement)
                return "Calm down, I know what I'm doing!";
            else
                return "Sure.";
        }
        else
        {
            if (statement.Any(char.IsLetter) && statement.ToUpper() == statement)
                return "Whoa, chill out!";
            else
                return "Whatever.";
        }
    }
}