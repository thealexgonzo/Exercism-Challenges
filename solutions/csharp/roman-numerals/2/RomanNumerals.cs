using Newtonsoft.Json.Linq;

public static class RomanNumeralExtension
{
    private static readonly Dictionary<int, string> numerals = new()
    {
        { 1000, "M" },
        { 900, "CM" },
        { 500, "D" },
        { 400, "CD" },
        { 100, "C" },
        { 90, "XC" },
        { 50, "L" },
        { 40, "XL" },
        { 10, "X" },
        { 9, "IX" },
        { 5, "V" },
        { 4, "IV" },
        { 1, "I" }
    };

    public static string ToRoman(this int value)
    {        
        string numeral = string.Empty;

        //foreach(var n in numerals.Keys)
        //{
        //    while(value >= n)
        //    {
        //        int numCheck = value - (value % n);

        //        if (numerals.Keys.Contains(numCheck))
        //        {
        //            numeral += numerals[numCheck];
        //            value -= numCheck;
        //        }
        //        else
        //        {
        //            numeral += numerals[n];
        //            value -= n;
        //        }
        //    }
        //}

        foreach(var pair in numerals)
        {
            while(value >= pair.Key)
            {
                numeral += pair.Value;
                value -= pair.Key;
            }
        }

        return numeral;
    }
}