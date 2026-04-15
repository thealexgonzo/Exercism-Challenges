[Flags]
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

public class Allergies
{
    private readonly Allergen _mask;
    public Allergies(int mask)
    {
        _mask = (Allergen)mask;
    }

    public bool IsAllergicTo(Allergen allergen) => 
        _mask.HasFlag(allergen);
    
    public Allergen[] List() => 
        Enum.GetValues<Allergen>()
            .Where(a => IsAllergicTo(a)).ToArray();    
}