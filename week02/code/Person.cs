public class Person
{
    public readonly string Name;
    public readonly bool IsInfinite;
    public int Turns { get; set; }

    internal Person(string name, int turns, bool isInfinite = false)
    {
        Name = name;
        Turns = turns;
        IsInfinite = isInfinite;
    }

    public override string ToString()
    {
        return Turns <= 0 ? $"({Name}:Forever)" : $"({Name}:{Turns})";
    }
}