public static class EliudsEggs
{
    public static int EggCount(int encodedCount)
    {
        int eggsInCoop = 0;

        //if (encodedCount.Equals(0))
        //    return 0;

        while (encodedCount != 0)
        {
            eggsInCoop += encodedCount % 2;
            encodedCount /= 2;
        }

        return eggsInCoop;
    }
}
