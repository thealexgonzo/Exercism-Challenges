public static class ReverseString
{
    public static string Reverse(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        string reversed = "";

        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed += input[i];
        }

        return reversed;
    }
}