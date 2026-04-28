using System.Text;

public static class RomanNumeralExtension
{
    private static readonly (int Value, string Symbol)[] numerals =
    {
        ( 1000, "M"),
        ( 900, "CM"),
        ( 500, "D" ),
        ( 400, "CD"),
        ( 100, "C" ),
        ( 90, "XC" ),
        ( 50, "L" ),
        ( 40, "XL" ),
        ( 10, "X" ),
        ( 9, "IX" ),
        ( 5, "V" ),
        ( 4, "IV" ),
        ( 1, "I" )
    };

    public static string ToRoman(this int value)
    {
        var result = new StringBuilder();

        foreach(var (val, symbol) in numerals)
        {
            while(value >= val)
            {
                result.Append(symbol);
                value -= val;
            }
        }

        return result.ToString();
    }
}