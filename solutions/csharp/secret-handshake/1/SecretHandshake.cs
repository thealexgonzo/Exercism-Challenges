public static class SecretHandshake
{
    private static readonly string[] _commands = [
            "wink",
            "double blink",
            "close your eyes",
            "jump"
        ];
    public static string[] Commands(int commandValue)
    {
        List<string> secretHandShake = new();

        var binaryCommandValue = new string(Convert.ToString(commandValue, 2)
            .Reverse()
            .ToArray());

        for (int i = 0; i < binaryCommandValue.Length; i++)
        {
            if (binaryCommandValue[i] == '1')
            {
                if(i == 4)
                    secretHandShake.Reverse();
                else
                    secretHandShake.Add(_commands[i]);
            }   
        }

        return secretHandShake.ToArray();  
    }
}
