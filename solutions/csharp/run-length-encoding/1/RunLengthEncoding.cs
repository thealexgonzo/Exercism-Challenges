using System.Xml.Linq;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        string encodedInput = "";

        for (int i = 0; i < input.Length; i++)
        {
            IEnumerable<char> characters = input.Substring(i).TakeWhile(c => c == input[i]);
            encodedInput += (characters.Count() == 1 ? "" : characters.Count()) + characters.Last().ToString();
            input = input.Substring(characters.Count() - 1);
        }       

        return encodedInput;
    }

    public static string Decode(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        int characterCount = 0;
        string decodedInput = "";

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                if(characterCount > 0) characterCount = (characterCount * 10) + input[i] - '0';
                else characterCount += input[i] - '0';
            }
            else
            {
                if(characterCount == 0) decodedInput += input[i];
                else
                {
                    for (int n = 0; n < characterCount; n++) decodedInput += input[i];

                    characterCount = 0;
                } 
            }
        }

        return decodedInput;
    }
}
