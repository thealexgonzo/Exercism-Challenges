using System.ComponentModel;
using System.Diagnostics;
using System.Text;

public class WordSearch
{
    private readonly string grid;
    private readonly string[] gridArray;
    private Dictionary<string, ((int, int), (int, int))?> wordCoordinates = new();
    private (int column, int row) firstCharacterCoords;
    private (int column, int row) lastCharacterCoords;

    public WordSearch(string grid)
    {
        this.grid = grid;
        gridArray = grid.Split('\n');
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        // Repeat for each word
        foreach(string word in wordsToSearchFor)
        {
            if(word.All(c => grid.Contains(c)))
            {
                string wordReversed = string.Join("", word.ToCharArray().Reverse());

                // Diagonal check
                DiagonalSearch(word, wordReversed);

                // Vertical check
                VerticalSearch(word, wordReversed);

                // Horizontal check
                HorizontalSearch(word, wordReversed);
            }
            else
            {
                wordCoordinates[word] = null;
            }
        }

        return wordCoordinates;
    }

    private void DiagonalSearch(string word, string wordReversed)
    {
        bool containsDiagonals = gridArray[0].Length >= 2;

        if (!containsDiagonals)
            return;

        // Check bottom left - top right
        for (int i = 0; i < gridArray.Length; i++)
        {
            int row = i;
            int col = 0;
            string lettersInDiagonal = string.Empty;

            
            while (row >= 0 && col <= gridArray.Length)
            {
                lettersInDiagonal += gridArray[row][col];
                row--;
                col++;
            }

            if (lettersInDiagonal.Contains(word) || lettersInDiagonal.Contains(wordReversed))
            {
                bool isReversed = lettersInDiagonal.Contains(wordReversed);

                firstCharacterCoords = isReversed ?
                    (firstCharacterCoords.column = lettersInDiagonal.IndexOf(wordReversed) + word.Length, 
                    firstCharacterCoords.row = i + 1) :
                    (firstCharacterCoords.column = lettersInDiagonal.IndexOf(word) + 1,
                     firstCharacterCoords.row = i - 1);

                lastCharacterCoords = isReversed ?
                    (lastCharacterCoords.column = lettersInDiagonal.IndexOf(wordReversed) + 1, 
                    lastCharacterCoords.row = i + 1) :
                    (lastCharacterCoords.column = lettersInDiagonal.IndexOf(word) + word.Length, 
                    lastCharacterCoords.row = i - word.Length);

                wordCoordinates[word] = ((firstCharacterCoords.column, firstCharacterCoords.row),
                                         (lastCharacterCoords.column, lastCharacterCoords.row));
                return;
            }
            else
            {
                continue;
            }
        }

        // Check bottom right - top left
        //for (int i = gridArray.Length - 1; i >= 0; i--)
        //{
        //    int row = i;
        //    int col = gridArray.First().Length - 1;

        //    string lettersInDiagonal = string.Empty;


        //    while (row >= 0 && col >= 0)
        //    {
        //        lettersInDiagonal += gridArray[row][col];
        //        row--;
        //        col--;
        //    }

        //    if (lettersInDiagonal.Contains(word) || lettersInDiagonal.Contains(wordReversed))
        //    {
        //        bool isReversed = lettersInDiagonal.Contains(wordReversed);

        //        firstCharacterCoords = isReversed ?
        //            (firstCharacterCoords.column = lettersInDiagonal.IndexOf(wordReversed) + word.Length,
        //            firstCharacterCoords.row = lettersInDiagonal.IndexOf(wordReversed) + word.Length) :
        //            (firstCharacterCoords.column = lettersInDiagonal.IndexOf(word) + 1,
        //             firstCharacterCoords.row = i + 1);

        //        lastCharacterCoords = isReversed ?
        //            (lastCharacterCoords.column = lettersInDiagonal.IndexOf(wordReversed) + 1,
        //            lastCharacterCoords.row = lettersInDiagonal.IndexOf(wordReversed) + 1) :
        //            (lastCharacterCoords.column = lettersInDiagonal.IndexOf(word) + word.Length,
        //            lastCharacterCoords.row = i + word.Length);

        //        wordCoordinates[word] = ((firstCharacterCoords.column, firstCharacterCoords.row),
        //                                 (lastCharacterCoords.column, lastCharacterCoords.row));
        //        return;
        //    }
        //    else
        //    {
        //        continue;
        //    }
        //}

        // Check top left to bottom right
        for (int i = gridArray.Length - 1; i >= 0; i--)
        {
            int row = i;
            int col = 0;
            string lettersInDiagonal = string.Empty;

            
            while (row < gridArray.Length && col <= gridArray.First().Length)
            {
                lettersInDiagonal += gridArray[row][col];
                row++;
                col++;
            }

            if (lettersInDiagonal.Contains(word) || lettersInDiagonal.Contains(wordReversed))
            {
                bool isReversed = lettersInDiagonal.Contains(wordReversed);

                firstCharacterCoords = isReversed ?
                    (firstCharacterCoords.column = lettersInDiagonal.IndexOf(wordReversed) + word.Length,
                    firstCharacterCoords.row = lettersInDiagonal.IndexOf(wordReversed) + word.Length + 1) :

                    (firstCharacterCoords.column = lettersInDiagonal.IndexOf(word) + 1,
                     firstCharacterCoords.row = i + 1);

                lastCharacterCoords = isReversed ?
                    (lastCharacterCoords.column = lettersInDiagonal.IndexOf(wordReversed) + 1,
                    lastCharacterCoords.row = lettersInDiagonal.IndexOf(wordReversed) + 2) :

                    (lastCharacterCoords.column = lettersInDiagonal.IndexOf(word) + word.Length,
                    lastCharacterCoords.row = i + word.Length);

                wordCoordinates[word] = ((firstCharacterCoords.column, firstCharacterCoords.row),
                                         (lastCharacterCoords.column, lastCharacterCoords.row));

                return;
            }
            else
            {
                continue;
            }
        }

        // Check top right - bottom left
        for (int i = 0; i < gridArray.Length; i++)
        {
            int row = i;
            int col = gridArray.First().Length - 1;

            string lettersInDiagonal = string.Empty;


            while (row < gridArray.Length && col >= 0)
            {
                lettersInDiagonal += gridArray[row][col];
                row++;
                col--;
            }

            //lettersInDiagonal = string.Join("", lettersInDiagonal.ToCharArray().Reverse());

            if (lettersInDiagonal.Contains(word) || lettersInDiagonal.Contains(wordReversed))
            {
                bool isReversed = lettersInDiagonal.Contains(wordReversed);

                firstCharacterCoords = isReversed ?
                    (firstCharacterCoords.column = lettersInDiagonal.IndexOf(wordReversed) + word.Length,
                    firstCharacterCoords.row = i - word.Length) :
                    (firstCharacterCoords.column = row - col,
                     firstCharacterCoords.row = row - word.Length);

                lastCharacterCoords = isReversed ?
                    (lastCharacterCoords.column = lettersInDiagonal.IndexOf(wordReversed) + 1,
                    lastCharacterCoords.row = lettersInDiagonal.IndexOf(wordReversed)) :
                    (lastCharacterCoords.column = lettersInDiagonal.IndexOf(word) + word.Length - 1,
                    lastCharacterCoords.row = row - lettersInDiagonal.IndexOf(word) + 1);

                wordCoordinates[word] = ((firstCharacterCoords.column, firstCharacterCoords.row),
                                         (lastCharacterCoords.column, lastCharacterCoords.row));
                return;
            }
            else
            {
                continue;
            }
        }

        // If at this point it doesn't contain the key, just set it to null
        if (!wordCoordinates.ContainsKey(word))
            wordCoordinates[word] = null;
    }

    private void VerticalSearch(string word, string wordReversed) 
    {
        for(int i = 0; i < gridArray.First().Length; i++)
        {
            int col = i + 1;
            string lettersInColumn = string.Empty;

            for (int x = 0; x < gridArray.Length; x++)
            {
                lettersInColumn += gridArray[x][i];
            }

            if (lettersInColumn.Contains(word) || lettersInColumn.Contains(wordReversed))
            {
                bool isBottomUp = lettersInColumn.Contains(wordReversed);

                
                firstCharacterCoords = isBottomUp ? 
                    (firstCharacterCoords.column = col, firstCharacterCoords.row = lettersInColumn.IndexOf(wordReversed) + word.Length) :
                    (firstCharacterCoords.column = col, firstCharacterCoords.row = lettersInColumn.IndexOf(word[0]) + 1);

                lastCharacterCoords = isBottomUp ?
                    (lastCharacterCoords.column = col, lastCharacterCoords.row = lettersInColumn.IndexOf(wordReversed) + 1) :
                    (lastCharacterCoords.column = col, lastCharacterCoords.row = lettersInColumn.IndexOf(word[word.Length - 1]) + 1);

                wordCoordinates[word] = ((firstCharacterCoords.column, firstCharacterCoords.row), 
                                         (lastCharacterCoords.column, lastCharacterCoords.row));
                return;
            }
            else
            {
                continue;
            }

        }

        // If at this point it doesn't contain the key, just set it to null
        if(!wordCoordinates.ContainsKey(word))
            wordCoordinates[word] = null;
    }
    private void HorizontalSearch(string word, string wordReversed)
    {
        foreach (string row in gridArray)
        {
            if (row.Contains(word) || row.Contains(wordReversed))
            {
                bool isRightToLeft = row.Contains(wordReversed);
                string currentWord = isRightToLeft ? wordReversed : word;
                int wordFinalIndex = 0;
                int index = 0;

                for (int characterIndex = 0; characterIndex < row.Length; characterIndex++)
                {
                    if (index == word.Length) break;

                    if (row[characterIndex] == currentWord[index])
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }

                    wordFinalIndex = characterIndex;
                }

                int wordStartIndex = isRightToLeft ? wordFinalIndex : wordFinalIndex - word.Length + 1;
                int wordEndIndex = isRightToLeft ? wordFinalIndex - word.Length + 1 : wordFinalIndex;

                firstCharacterCoords = (wordStartIndex + 1, gridArray.IndexOf(row) + 1);
                lastCharacterCoords = (wordEndIndex + 1, gridArray.IndexOf(row) + 1);
                wordCoordinates[word] = (firstCharacterCoords, lastCharacterCoords);
                return;
            }
            else
            {
                if (!wordCoordinates.ContainsKey(word))
                {
                    wordCoordinates[word] = null;
                }

                continue;
            }
        }
    }
}


// Search for the first instance of the first character then look in all directions until found              

// left to right -- DONE
// right to left -- DONE
// bottom to top -- DONE
// top to bottom -- DONE
// diagonal (left to right + bottom to top) -- DONE
// diagonal (left to right + top to bottom) -- DONE
// diagonal (right to left + bottom to top)
// diagonal (right to left + bottom to top)
// If not found mark the word as null -- DONE
// else mark the positions of first and last character -- DONE