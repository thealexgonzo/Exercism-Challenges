public static class Raindrops
{
    public static string Convert(int number)
    {
        string rainDrops = "";

        if (number % 3 == 0)
            rainDrops += "Pling";
        if (number % 5 == 0)
            rainDrops += "Plang";
        if (number % 7 == 0)
            rainDrops += "Plong";

        return rainDrops == "" ? number.ToString() : rainDrops;
    }
}