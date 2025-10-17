using System.ComponentModel.Design;

public static class SquareRoot
{
    public static int Root(int number)
    {
        //for (int i = 1; i <= number; i++)
        //{
        //    if (i * i == number)
        //    {
        //        return i;
        //    }
        //}

        //return 1;

        int x = 0;

        while(x * x != number)
        {
            x++;
        }

        return x;
    }
}
