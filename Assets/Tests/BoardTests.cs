using Data;
using NUnit.Framework;

namespace Tests
{
    public class BoardTests
    {
        private const int X_SIZE = 3, Y_SIZE = 3;

        [Test]
        public void BoardTestsSimplePasses()
        {
            //Arrange
            //Act
            //Assert
            Assert.Pass();
        }

        [Test]
        public void CreateBoardValidSizesPasses()
        {
            //Arrange

            //Act
            BoardState boardState = new(X_SIZE, Y_SIZE);

            //Assert
            Assert.AreEqual(X_SIZE, boardState.XSize);
            Assert.AreEqual(Y_SIZE, boardState.YSize);
        }

        [Test]
        public void CreateBoardAllCellsAreEmpty()
        {
            //Arrange
            BoardState boardState = new(X_SIZE, Y_SIZE);

            //Act

            for (int y = 0; y < Y_SIZE; y++)
            {
                for (int x = 0; x < X_SIZE; x++)
                {
                    Cell cell = boardState.GetCell(x, y);
                    Assert.IsTrue(cell.State == ECellState.Empty);
                }
            }
        }

        [Test]
        public void EnumeratorGoesThroughAllCells()
        {
            //Arrange
            BoardState boardState = new(X_SIZE, Y_SIZE);
            int count = 0;

            //Act
            foreach (Cell _ in boardState)
            {
                count++;
            }

            //Assert
            Assert.AreEqual(Y_SIZE * X_SIZE, count);
        }

        [Test]
        public void ChangeStateOfOneCell_NotAllAreEmpty()
        {
            //Arrange
            BoardState boardState = new(X_SIZE, Y_SIZE);
            bool isBoardEmpty = true;

            //Act
            boardState.GetCell(0, 0).State = ECellState.X;

            //Assert
            foreach (Cell cell in boardState)
            {
                isBoardEmpty &= cell.State == ECellState.Empty;
            }

            Assert.IsFalse(isBoardEmpty);
        }
    }
}