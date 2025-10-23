using System.Diagnostics.Tracing;

public class Anagram
{
    private readonly string _baseWord;
    public Anagram(string baseWord) => _baseWord = baseWord;

    public string[] FindAnagrams(string[] potentialMatches) => 
        potentialMatches.Where(IsAnagram).ToArray();
    private bool IsAnagram(string potentialMatch) => 
        AreDifferent(potentialMatch) && SortWord(_baseWord) == SortWord(potentialMatch);

    private bool AreDifferent(string potentialMatch) => 
        !string.Equals(potentialMatch, _baseWord, StringComparison.OrdinalIgnoreCase);

    private string SortWord(string word)
    {
        //char[] currentWord = word.ToLower().Order().ToArray();
        return new string(word.ToLower().Order().ToArray());
    }
}