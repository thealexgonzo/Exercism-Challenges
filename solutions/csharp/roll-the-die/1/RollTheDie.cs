public class Player
{
    private Random dieRoll = new();
    public int RollDie() => dieRoll.Next(1, 19);
    public double GenerateSpellStrength() => dieRoll.NextDouble() * 100;
}
