using System.Collections.Generic;
using System.Runtime.CompilerServices;

public static class BottleSong
{
    private static readonly string[] NumbersToWordsConverter = [
        "One", "Two", "Three", "Four", "Five", "Six", "Seven",
        "Eight", "Nine", "Ten"
        ];

    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        List<string> lyrics = new();

        string plural = "bottles";
        string singular = "bottle";

        while(takeDown > 0)
        {
            lyrics.Add($"{NumbersToWordsConverter[startBottles - 1]} green " 
                + (startBottles > 1 ? plural : singular) 
                + " hanging on the wall,");

            lyrics.Add($"{NumbersToWordsConverter[startBottles - 1]} green " 
                + (startBottles > 1 ? plural : singular) 
                + " hanging on the wall,");
            
            lyrics.Add("And if one green bottle should accidentally fall,");

            startBottles--;

            if(startBottles > 0)
            {
                lyrics.Add($"There'll be {NumbersToWordsConverter[startBottles - 1].ToLower()} green "
                + (startBottles > 1 ? plural : singular)
                + " hanging on the wall.");

                if(takeDown > 1)
                    lyrics.Add("");
            }
            else
            {
                lyrics.Add("There'll be no green bottles hanging on the wall.");
            }

            takeDown--;
        }

        return lyrics.ToArray();
    }
}
