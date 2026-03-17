public static class Isogram
{
    public static bool IsIsogram(string word) => 
        word.ToLower().Where(char.IsLetter).Distinct().Count() ==
        word.ToLower().Count(char.IsLetter);
}
