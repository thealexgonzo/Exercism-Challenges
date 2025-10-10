public static class ScrabbleScore
{
    public static int Score(string input)
    {
        int score = 0;

        Dictionary<string, int> letterPoints = new Dictionary<string, int>
        {
            { "aeioulnrst", 1 },
            { "dg", 2 },
            { "bcmp", 3 },
            { "fhvwy", 4 },
            { "k", 5 },
            { "jx", 8 },
            { "qz", 10 }
        };

        foreach(char letter in input)
        {
            foreach(string set in letterPoints.Keys)
            {
                if (set.Contains(letter.ToString().ToLower()))
                {
                    score += letterPoints[set];
                }
            }
        }

        return score;
    }
}