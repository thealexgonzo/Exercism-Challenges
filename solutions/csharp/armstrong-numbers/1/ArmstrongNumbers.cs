using Xunit.Runner.Common;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        string digits = number.ToString();
        return digits.Sum(d => (int)Math.Pow(int.Parse(d.ToString()), digits.Length)) == number;
    }
}