public static class ResistorColor
{
    private static string[] _colors = [
            "black",
            "brown",
            "red",
            "orange",
            "yellow",
            "green",
            "blue",
            "violet",
            "grey",
            "white"
            ];
    public static int ColorCode(string color)
    {
        return Array.IndexOf(Colors(), color);
    }

    public static string[] Colors()
    {
        return _colors;
    }
}