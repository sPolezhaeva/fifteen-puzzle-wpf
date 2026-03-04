using System;

namespace LevelGenerator
{
    public class MoveValidator
    {
        private readonly int[,] _board;
        private readonly int _size;

        public MoveValidator(int[,] board)
        {
            _board = board;
            _size = (int)Math.Sqrt(board.Length);
        }

        public bool IsValidMove(int emptyTileRow, int emptyTileCol, int tileRow, int tileCol)
        {
            if (tileRow < 0 || tileRow >= _size || tileCol < 0 || tileCol >= _size)
            {
                return false;
            }

            if (Math.Abs(emptyTileRow - tileRow) + Math.Abs(emptyTileCol - tileCol) == 1)
            {
                return true;
            }

            return false;
        }
    }
}