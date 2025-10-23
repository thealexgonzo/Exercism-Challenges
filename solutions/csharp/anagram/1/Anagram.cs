using System.Diagnostics.Tracing;

public class Anagram
{
    private string _baseWord;
    public Anagram(string baseWord)
    {
        _baseWord = baseWord;
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> anagramsFound = new();

        foreach(string word in potentialMatches)
        {
            if(word.Length == _baseWord.Length && word.ToLower() != _baseWord.ToLower())
            {
                if(SortWord(_baseWord) == SortWord(word))
                {
                    anagramsFound.Add(word);
                }
            }
        }

        return anagramsFound.ToArray();
    }

    private string SortWord(string word)
    {
        char[] currentWord = word.ToLower().ToArray();
        Array.Sort(currentWord);
        return new string(currentWord);
    }
}