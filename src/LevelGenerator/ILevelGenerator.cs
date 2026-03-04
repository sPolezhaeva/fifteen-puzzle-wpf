namespace LevelGenerator
{
    public interface ILevelGenerator
    {
        int[,] GeneratePuzzle(int size);
        bool ValidateMove(int[,] board, int emptyTileRow, int emptyTileCol, int targetRow, int targetCol);
    }
}