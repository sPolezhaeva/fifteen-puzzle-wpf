using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LevelGenerator;

namespace LevelGenerator.Tests
{
    [TestClass]
    public class LevelGeneratorTests
    {
        private ILevelGenerator _levelGenerator;

        [TestInitialize]
        public void Setup()
        {
            _levelGenerator = new PuzzleGenerator();
        }

        [TestMethod]
        public void GeneratePuzzle_ShouldCreateValidPuzzle()
        {
            int size = 4;
            var board = _levelGenerator.GeneratePuzzle(size);

            Assert.IsNotNull(board);
            Assert.AreEqual(size, board.GetLength(0));
            Assert.AreEqual(size, board.GetLength(1));
        }

        [TestMethod]
        public void ValidateMove_ShouldReturnTrueForValidMove()
        {
            var board = new Board(4);
            board.Initialize();

            var result = _levelGenerator.ValidateMove(board, 1); 

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateMove_ShouldReturnFalseForInvalidMove()
        {
            var board = new Board(4);
            board.Initialize();

            var result = _levelGenerator.ValidateMove(board, 99);

            Assert.IsFalse(result);
        }
    }
}