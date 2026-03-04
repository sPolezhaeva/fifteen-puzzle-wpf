using System;
using System.Collections.Generic;
using System.Linq;

namespace LevelGenerator
{
    public class PuzzleGenerator : ILevelGenerator
    {
        private Random _random = new Random();

        public int[,] GeneratePuzzle(int size)
        {
            if (size < 2) throw new ArgumentException("Size must be at least 2.");
            int[,] board = new int[size, size];
            int total = size * size;
            for (int i = 0; i < total - 1; i++)
            {
                int r = i / size;
                int c = i % size;
                board[r, c] = i + 1;
            }
            board[size - 1, size - 1] = 0; // blank

            int moves = Math.Max(100, size * size * 50);
            int prevR = -1, prevC = -1;
            int blankR = size - 1, blankC = size - 1;
            for (int m = 0; m < moves; m++)
            {
                var neighbors = GetNeighbors(blankR, blankC, size);
                if (prevR != -1)
                {
                    neighbors.RemoveAll(t => t.Item1 == prevR && t.Item2 == prevC);
                    if (neighbors.Count == 0)
                    {
                        neighbors = GetNeighbors(blankR, blankC, size);
                    }
                }

                var choice = neighbors[_random.Next(neighbors.Count)];
                int nr = choice.Item1, nc = choice.Item2;
                board[blankR, blankC] = board[nr, nc];
                board[nr, nc] = 0;

                prevR = blankR; prevC = blankC;
                blankR = nr; blankC = nc;
            }

            return board;
        }

        private void Shuffle(List<int> tiles)
        {
            for (int i = tiles.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                int temp = tiles[i];
                tiles[i] = tiles[j];
                tiles[j] = temp;
            }
        }

        public bool IsSolvable(int[,] board)
        {
            int inversions = 0;
            int size = board.GetLength(0);
            List<int> flatBoard = new List<int>();
            int blankRow = -1; 

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int tile = board[i, j];
                    if (tile == 0)
                    {
                        blankRow = i;
                        continue;
                    }
                    flatBoard.Add(tile);
                }
            }

            for (int i = 0; i < flatBoard.Count; i++)
            {
                for (int j = i + 1; j < flatBoard.Count; j++)
                {
                    if (flatBoard[i] > flatBoard[j]) inversions++;
                }
            }

            if (size % 2 == 1)
            {
                return inversions % 2 == 0;
            }
            else
            {
                int rowFromBottom = size - blankRow;
                return (inversions + rowFromBottom) % 2 == 1;
            }
        }

        private int[,] ListToBoard(List<int> tiles, int size)
        {
            var board = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = tiles[i * size + j];
                }
            }
            return board;
        }

        private System.Collections.Generic.List<(int,int)> GetNeighbors(int r, int c, int size)
        {
            var res = new System.Collections.Generic.List<(int,int)>();
            if (r > 0) res.Add((r - 1, c));
            if (r < size - 1) res.Add((r + 1, c));
            if (c > 0) res.Add((r, c - 1));
            if (c < size - 1) res.Add((r, c + 1));
            return res;
        }

        public bool ValidateMove(int[,] board, int emptyTileRow, int emptyTileCol, int targetRow, int targetCol)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            if (emptyTileRow < 0 || emptyTileRow >= rows || emptyTileCol < 0 || emptyTileCol >= cols) return false;
            if (targetRow < 0 || targetRow >= rows || targetCol < 0 || targetCol >= cols) return false;

            int rowDiff = Math.Abs(emptyTileRow - targetRow);
            int colDiff = Math.Abs(emptyTileCol - targetCol);

            return (rowDiff + colDiff) == 1;
        }
    }
}