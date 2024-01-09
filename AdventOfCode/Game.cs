public struct Game
{
    public int Id { get; }
    public int Blue { get; }
    public int Red { get; }
    public int Green { get; }

    public Game(int id, int blue, int red, int green)
    {
        Id = id;
        Blue = blue;
        Red = red;
        Green = green;
    }

    public readonly bool Contains(int blue, int red, int green)
    {
        return Blue <= blue && Red <= red && Green <= green;
    }
}