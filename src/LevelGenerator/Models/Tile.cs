public class Tile
{
    public int Value { get; set; }
    public (int Row, int Column) Position { get; set; }

    public Tile(int value, int row, int column)
    {
        Value = value;
        Position = (row, column);
    }
}