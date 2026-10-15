public class DndCharacter
{
    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Intelligence { get; private set; }
    public int Wisdom { get; private set; }
    public int Charisma { get; private set; }
    public int Hitpoints { get; private set; }

    public static int Modifier(int score)
    {
        return (int)Math.Floor((score - 10.0) / 2);
    }

    public static int Ability() 
    {
        List<int> dice = new();
        Random die = new();
        int totalDiceRolls = 4;

        for (int roll = 0; roll < totalDiceRolls; roll++)
            dice.Add(die.Next(1, 7));
        

        dice.Remove(dice.Min());
        return dice.Sum();
    }

    public static DndCharacter Generate()
    {
        DndCharacter character = new();
        character.Strength = Ability();
        character.Dexterity = Ability();
        character.Constitution = Ability();
        character.Intelligence = Ability();
        character.Wisdom = Ability();
        character.Charisma = Ability();
        character.Hitpoints = 10 + Modifier(character.Constitution);

        return character;
    }
}
