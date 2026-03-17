public static class RotationalCipher
{
    private static readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static string Rotate(string text, int shiftKey) => 
        new string(text.Select(c =>
                        char.IsLetter(c) && shiftKey != 26 ?
                            char.IsUpper(c) ? 
                                char.ToUpper(alphabet[alphabet.IndexOf(char.ToLower(c)) + ShouldWrap(char.ToLower(c), shiftKey)]) 
                                : alphabet[alphabet.IndexOf(c) + ShouldWrap(c, shiftKey)] 
                        : c)
                        .ToArray());

    public static int ShouldWrap(char letter, int shiftKey) =>
        alphabet.IndexOf(letter) + shiftKey >= 26 ? (26 - shiftKey) * -1 : shiftKey;

}