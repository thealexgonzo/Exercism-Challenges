public class Robot
{    
    private static HashSet<string> _nameHistory = new();
    private readonly static Random _random = new();
    private string _name = string.Empty;
    public string Name
    {        
        get
        {
            if (string.IsNullOrEmpty(_name)) Reset();
            return _name;
        }
    }

    public void Reset()
    {
        string namePlaceHolder = string.Empty;

        do
        {
            char firstLetter = (char)_random.Next('A', '[');
            char secondLetter = (char)_random.Next('A', '[');
            int threeDigits = _random.Next(100, 1000);
            namePlaceHolder = $"{firstLetter}{secondLetter}{threeDigits}";

        } while (!_nameHistory.Add(namePlaceHolder));

        _name = namePlaceHolder;
    }
}