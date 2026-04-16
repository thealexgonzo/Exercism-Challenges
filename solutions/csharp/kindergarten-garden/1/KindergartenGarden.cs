public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public class KindergartenGarden
{
    private readonly string[] _diagram;
    private static readonly string[] Students =
    {
        "Alice", "Bob", "Charlie", "David", "Eve", "Fred",
        "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid",
        "Larry"
    };
    public KindergartenGarden(string diagram)
    {
        _diagram = diagram.Split('\n');       
    }

    public IEnumerable<Plant> Plants(string student)
    {
        int studentIndex = Array.IndexOf(Students, student);
        if (studentIndex == -1) return [];

        int start = studentIndex * 2;

        return
        [
            (Plant)_diagram[0][start],
            (Plant)_diagram[0][start + 1],
            (Plant)_diagram[1][start],
            (Plant)_diagram[1][start + 1]
        ];
    }
}