public static class ResistorColorDuo
{
    private static readonly Dictionary<string, string> colourValues = new()
        {
            {"black", "0" },
            {"brown", "1" },
            {"red", "2" },
            {"orange", "3" },
            {"yellow", "4" },
            {"green", "5" },
            {"blue", "6" },
            {"violet", "7" },
            {"grey", "8" },
            {"white", "9" }
        };
    public static int Value(string[] colors)
    {
        return int.Parse(colourValues[colors[0]] + colourValues[colors[1]]);
    }
}
