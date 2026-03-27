using System.CodeDom.Compiler;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Xml;
using System.Xml.Linq;

using Exercism;

public class Robot
{    
    private static HashSet<string> _nameHistory = new();
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

        while (!_nameHistory.Add(namePlaceHolder))
        {
            Random digitGenerator = new();
            char firstLetter = (char)digitGenerator.Next(65, 91);
            char secondLetter = (char)digitGenerator.Next(65, 91);
            int threeDigits = digitGenerator.Next(100, 1000);
            namePlaceHolder = $"{firstLetter}{secondLetter}{threeDigits}";
        }

        //do
        //{
        //    Random digitGenerator = new();
        //    char firstLetter = (char)digitGenerator.Next(65, 91);
        //    char secondLetter = (char)digitGenerator.Next(65, 91);
        //    int threeDigits = digitGenerator.Next(100, 1000);            
        //    namePlaceHolder = $"{firstLetter}{secondLetter}{threeDigits}";

        //} while (!_nameHistory.Add(namePlaceHolder));

        _name = namePlaceHolder;
    }
}