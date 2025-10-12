public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        List<(int, int)> result = new List<(int, int)>();

        if (matrix.Length == 0)
            return result;

        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                //int currentNumber = matrix[i, j];
                //(int, int) currentIndex = (i, j);

                if(IsSmallestInColumn(matrix, matrix[i, j], j)
                    && IsLargestInRow(matrix, matrix[i, j], i))
                {
                    result.Add((i + 1, j + 1));
                }

            }
        }
        return result;
    }

    private static bool IsSmallestInColumn(int[,] matrix, int currentNumber, int columnIndex)
    {
        int smallestInColumn = int.MaxValue;

        for(int j = 0; j < matrix.GetLength(0); j++)
        {
            if (matrix[j, columnIndex] < smallestInColumn)
            {
                smallestInColumn = matrix[j, columnIndex];
            }
        }
        
        return smallestInColumn == currentNumber;
    }

    private static bool IsLargestInRow(int[,] matrix, int currentNumber, int rowIndex)
    {
        int largestInRow = int.MinValue;

        for(int x = 0; x < matrix.GetLength(1); x++)
        {
            if (matrix[rowIndex, x] > largestInRow)
            {
                largestInRow = matrix[rowIndex, x];
            }
        }

        return largestInRow == currentNumber;
    }
}

