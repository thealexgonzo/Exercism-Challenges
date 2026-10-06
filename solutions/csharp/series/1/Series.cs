public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength <= 0 || sliceLength > numbers.Length)
            throw new ArgumentException();

        List<string> slices = new();

        for (int i = 0; i + sliceLength <= numbers.Length; i++)
        {            
            slices.Add(numbers.Substring(i, sliceLength));
        }

        return slices.ToArray();
    }
}