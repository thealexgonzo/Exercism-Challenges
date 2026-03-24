public static class Languages
{
    public static List<string> NewList() =>
        new List<string>();
    public static List<string> GetExistingLanguages() =>
        new List<string>() { "C#", "Clojure", "Elm" };
    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages) =>
        languages.Count();

    public static bool HasLanguage(List<string> languages, string language) =>
        languages.Contains(language);

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        var count = languages.Count();

        if (count == 0 || count > 3) return false;

        return languages[0] == "C#" || (count > 1 && languages[1] == "C#");
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        HashSet<string> set = new();
        
        foreach(var lang in languages)
        {
            bool added = set.Add(lang);
            if (!added) return false;
        }

        return true;
    }
}
