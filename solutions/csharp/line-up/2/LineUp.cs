public static class LineUp
{
    public static string Format(string name, int number)
    {
        int suffixKey = number % 100 >= 11 && number % 100 <= 13 ? 0 : number % 10;
        bool val = number % 100 is 11 or 12 or 13;

        string ordinal = number % 100 is 11 or 12 or 13 ? "th" :
            (number % 10) switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th"
            };

        return $"{name}, you are the {number}{ordinal} customer we serve today. Thank you!";
    }
}


