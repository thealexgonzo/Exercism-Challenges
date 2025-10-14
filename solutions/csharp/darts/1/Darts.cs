public static class Darts
{
    public static int Score(double x, double y)
    {
        double distanceFromCentre = Math.Sqrt((x * x) + (y * y));

        if (distanceFromCentre >= -1 && distanceFromCentre <= 1)
            return 10;
        else if (distanceFromCentre >= -5 && distanceFromCentre <= 5)
            return 5;
        else if (distanceFromCentre >= -10 && distanceFromCentre <= 10)
            return 1;

        return 0;
    }
}
