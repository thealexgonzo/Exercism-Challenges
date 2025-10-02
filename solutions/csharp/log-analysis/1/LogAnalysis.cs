using System.Runtime.CompilerServices;

public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string del)
    {
        string delimeter = del.Length > 1 ? del[del.Length - 1].ToString() : del;

        return str.Substring(str.IndexOf(delimeter) + 1);
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string del1, string del2)
    {
        string[] words = str.Remove(str.IndexOf(del2)).Split(del1);
        return words[words.Length - 1];
    }

    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}