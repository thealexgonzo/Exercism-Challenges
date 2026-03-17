public static class Pangram
{
    private static readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";
    public static bool IsPangram(string input)
    {
        var lowerCaseInput = input.ToLower();

        //foreach (var letter in alphabet)
        //{
        //    if (!lowerCaseInput.Contains(letter)) return false;
        //}

        return alphabet.All(i => lowerCaseInput.Contains(i));
    }
}
