public enum Allergen
{
    Eggs = 1, // 0001
    Peanuts = 2, // 0010
    Shellfish = 4, // 0100
    Strawberries = 8, // 1000
    Tomatoes = 16, // 10000
    Chocolate = 32, // 100000
    Pollen = 64, // 1000000
    Cats = 128 // 10000000
}

// 112
// 1110000

public class Allergies
{
    private readonly int _mask;
    public Allergies(int mask)
    {
        _mask = mask;
    }

    public bool IsAllergicTo(Allergen allergen) => 
        (_mask & (int)allergen) == (int)allergen;
    
    public Allergen[] List() => 
        Enum.GetValues<Allergen>()
            .Where(a => IsAllergicTo(a)).ToArray();    
}