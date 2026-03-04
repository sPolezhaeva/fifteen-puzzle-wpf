using System;

namespace LevelGenerator.Models
{
    public class Board
    {
        private int[,] _tiles;
        private int _size;

        public Board(int size)
        {
            _size = size;
            _tiles = new int[size, size];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            int tileValue = 1;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (tileValue < _size * _size)
                    {
                        _tiles[i, j] = tileValue++;
                    }
                    else
                    {
                        _tiles[i, j] = 0;
                    }
                }
            }
        }

        public int GetTile(int row, int col)
        {
            return _tiles[row, col];
        }

        public void SetTile(int row, int col, int value)
        {
            _tiles[row, col] = value;
        }

        public int Size => _size;

        public bool IsSolved()
        {
            int tileValue = 1;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (i == _size - 1 && j == _size - 1)
                    {
                        return _tiles[i, j] == 0; 
                    }
                    if (_tiles[i, j] != tileValue++)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}