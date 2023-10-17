using System;
using System.Drawing;
using NUnit.Framework;
using System.Windows.Forms;

namespace Pacman.Tests
{
    [TestFixture]
    public class GameBoardTests
    {
        private GameBoard gameBoard;

        [SetUp]
        public void SetUp()
        {
            gameBoard = new GameBoard();
        }

        [Test]
        public void CreateBoardImageTest()
        {
            Form form = new Form();
            gameBoard.CreateBoardImage(form, 1);

            Assert.IsNotNull(gameBoard.BoardImage);
            Assert.AreEqual("BoardImage", gameBoard.BoardImage.Name);
            Assert.AreEqual(PictureBoxSizeMode.AutoSize, gameBoard.BoardImage.SizeMode);
            Assert.AreEqual(new Point(0, 50), gameBoard.BoardImage.Location);
            Assert.AreEqual(form, gameBoard.BoardImage.Parent);
        }

        [Test]
        public void InitialiseBoardMatrixTest()
        {
            int level = 1;
            Tuple<int, int> startLocation = gameBoard.InitialiseBoardMatrix(level);

            Assert.AreEqual(31, gameBoard.Matrix.GetLength(0));
            Assert.AreEqual(28, gameBoard.Matrix.GetLength(1));

            Assert.AreEqual(3, gameBoard.Matrix[startLocation.Item2, startLocation.Item1]);
        }
    }
}
