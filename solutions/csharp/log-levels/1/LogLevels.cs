static class LogLine
{
    public static string Message(string logLine)
    {
        int spacePosition = logLine.IndexOf(" ");
        return logLine.Substring(spacePosition).Trim();
    }

    public static string LogLevel(string logLine)
    {
        int spacePosition = logLine.IndexOf("]");
        string first = logLine.Remove(spacePosition);
        string second = first.Substring(1);
        
        return second.ToLower();
    }

    public static string Reformat(string logLine)
    {
        int spacePosition = logLine.IndexOf(" ");
        int bracketPosition = logLine.IndexOf("]");
        string message = logLine.Substring(spacePosition + 1).Trim();

        string warning = logLine.Remove(bracketPosition).Trim();

        return message + " " + "(" + warning.Substring(1).ToLower() + ")";
    }
}
