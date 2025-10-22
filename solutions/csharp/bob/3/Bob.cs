public static class Bob
{
    public static string Response(string statement)
    {
        bool isYelling = statement.Any(char.IsLetter) && statement.ToUpper() == statement;

        if (string.IsNullOrWhiteSpace(statement))
        {
            return "Fine. Be that way!";
        }
        else if (statement.TrimEnd().EndsWith('?'))
        {
            if (isYelling)
                return "Calm down, I know what I'm doing!";
            else
                return "Sure.";
        }
        else
        {
            if (isYelling)
                return "Whoa, chill out!";
            else
                return "Whatever.";
        }
    }
}