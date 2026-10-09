using System.ComponentModel.Design;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            checked
            {
                return $"{@base * multiplier}";
            }
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        try
        {
            checked
            {
                return $"{(decimal)@base * (decimal)multiplier}";
            }
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            checked
            {
                return $"{salaryBase * multiplier}";
            }
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }
    }
}
