
using System.Text.RegularExpressions;

public static class Acronym
{
    public static string Abbreviate(string phrase) =>
        String.Concat(Regex.Split(phrase, "[^A-Za-z']+").Select(word => char.ToUpper(word[0])));

}


//new string(
//    phrase
//        .Replace('-', ' ')
//        .Replace('_', ' ')
//        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
//        .Select(word => char.ToUpper(word[0]))
//        .ToArray()
//    );    