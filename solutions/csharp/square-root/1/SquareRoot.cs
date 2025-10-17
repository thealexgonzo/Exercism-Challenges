using System.ComponentModel.Design;

public static class SquareRoot
{
    public static int Root(int number)
    {
        for (int i = 1; i <= number; i++)
        {
            if (i * i == number)
            {
                return i;
            }
        }

        return 1;
    }
}
