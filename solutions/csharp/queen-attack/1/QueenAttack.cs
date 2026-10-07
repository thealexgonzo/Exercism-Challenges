public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        if (white.Column == black.Column || white.Row == black.Row)
            return true;
        else if (CanAttackOnFirstDiagonal(white, black))
            return true;
        else if (CanAttackOnSecondDiagonal(white, black))
            return true;
        else if (CanAttackOnThirdDiagonal(white, black))
            return true;
        else if (CanAttackOnFourthDiagonal(white, black))
            return true;
        else
            return false;
    }

    public static Queen Create(int row, int column)
    {
        if (row < 0 || column < 0 || row > 7 || column > 7)
            throw new ArgumentOutOfRangeException();

        return new Queen(row, column);
    }

    public static bool CanAttackOnFirstDiagonal(Queen white, Queen black)
    {
        int row = white.Row;
        int col = white.Column;

        while (row >= 0 && col <= 7)
        {
            --row;
            ++col;
            if (black.Row == row && black.Column == col)
                return true;
        }

        return false;
    }

    public static bool CanAttackOnSecondDiagonal(Queen white, Queen black)
    {
        int row = white.Row;
        int col = white.Column;

        while (row <= 7 && col >= 0)
        {
            ++row;
            --col;
            if (black.Row == row && black.Column == col)
                return true;
        }

        return false;
    }

    public static bool CanAttackOnThirdDiagonal(Queen white, Queen black)
    {
        int row = white.Row;
        int col = white.Column;

        while (row >= 0 && col >= 0)
        {
            --row;
            --col;
            if (black.Row == row && black.Column == col)
                return true;
        }

        return false;
    }

    public static bool CanAttackOnFourthDiagonal(Queen white, Queen black)
    {
        int row = white.Row;
        int col = white.Column;

        while (row <= 7 && col <= 7)
        {
            ++row;
            ++col;

            if (black.Row == row && black.Column == col)
                return true;
        }

        return false;
    }
}