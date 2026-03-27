public static class LineUp
{
    private static Dictionary<int, string> _ordinals = new()
    {
        { 1, "st" },
        { 2, "nd" },
        { 3, "rd" }
    };

    public static string Format(string name, int number)
    {
        int position = number % 100 >= 11 && number % 100 <= 13 ? 0 : number % 10;

        return $"{name}, you are the {number}" +
            $"{(_ordinals.Keys.Contains(position) ? _ordinals[position] : "th")}" +
            $" customer we serve today. Thank you!";
    }
}


