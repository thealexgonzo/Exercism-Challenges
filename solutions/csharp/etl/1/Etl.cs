public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> newDict = new();

        foreach(int key in old.Keys)
        {
            foreach(string letter in old[key])
            {
                newDict.Add(letter.ToLower(), key);
            }
        }

        return newDict;
    }
}