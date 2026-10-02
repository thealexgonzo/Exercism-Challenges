public static class Grains
{
    private static int squaresOnChessBoard = 64;
    public static ulong Square(int n)
    {
        if (n <= 0 || n > squaresOnChessBoard)
            throw new ArgumentOutOfRangeException();

        return (ulong)Math.Pow(2, n - 1);
    }

    public static ulong Total()
    {
        return (ulong)Math.Pow(2, squaresOnChessBoard);
    }
}