using Data;
using NUnit.Framework;

namespace Tests
{
  public class WinLoseTests
  {
    private const int X_SIZE = 3, Y_SIZE = 3;

    [Test]
    public void WinLoseTestsPasses()
    {
      Assert.Pass();
    }

    [Test]
    public void HorizontalWinOneIsFound()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.X;

      // X X X
      // - - -
      // - - -
      boardState.GetCell(0, 0).State = winnerState;
      boardState.GetCell(1, 0).State = winnerState;
      boardState.GetCell(2, 0).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForHorizontalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsTrue(result);
      Assert.AreEqual(winnerState, winner);
    }

    [Test]
    public void HorizontalWinForOIsFound()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.O;

      // O O O
      // - - -
      // - - -
      boardState.GetCell(0, 0).State = winnerState;
      boardState.GetCell(1, 0).State = winnerState;
      boardState.GetCell(2, 0).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForHorizontalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsTrue(result);
      Assert.AreEqual(winnerState, winner);
    }

    [Test]
    public void HorizontalWinTwoIsFound()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.X;

      // - - -
      // X X X
      // - - -
      boardState.GetCell(0, 1).State = winnerState;
      boardState.GetCell(1, 1).State = winnerState;
      boardState.GetCell(2, 1).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForHorizontalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsTrue(result);
      Assert.AreEqual(winnerState, winner);
    }

    [Test]
    public void HorizontalWinThreeIsFound()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.X;

      // - - -
      // - - -
      // X X X
      boardState.GetCell(0, 2).State = winnerState;
      boardState.GetCell(1, 2).State = winnerState;
      boardState.GetCell(2, 2).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForHorizontalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsTrue(result);
      Assert.AreEqual(winnerState, winner);
    }

    [Test]
    public void InvalidHorizontalWinOneIsNotFound()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.X;

      // - - -
      // - - -
      // X X -
      boardState.GetCell(0, 2).State = winnerState;
      boardState.GetCell(1, 2).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForHorizontalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsFalse(result);
      Assert.AreEqual(ECellState.Empty, winner);
    }

    [Test]
    public void InvalidHorizontalWinTwoIsNotFound()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.X;

      // - - -
      // - - -
      // X - -
      boardState.GetCell(0, 2).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForHorizontalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsFalse(result);
      Assert.AreEqual(ECellState.Empty, winner);
    }

    [Test]
    public void InvalidHorizontalWinThreeIsNotFound()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.X;

      // X - -
      // X - -
      // X - -
      boardState.GetCell(0, 0).State = winnerState;
      boardState.GetCell(0, 1).State = winnerState;
      boardState.GetCell(0, 2).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForHorizontalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsFalse(result);
      Assert.AreEqual(ECellState.Empty, winner);
    }

    [Test]
    public void ValidVerticalWinOneIsFound()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.X;

      // X - -
      // X - -
      // X - -
      boardState.GetCell(0, 0).State = winnerState;
      boardState.GetCell(0, 1).State = winnerState;
      boardState.GetCell(0, 2).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForVerticalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsTrue(result);
      Assert.AreEqual(winnerState, winner);
    }

    [Test]
    public void ValidVerticalWinTwoIsFound()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.X;

      // - X -
      // - X -
      // - X -
      boardState.GetCell(1, 0).State = winnerState;
      boardState.GetCell(1, 1).State = winnerState;
      boardState.GetCell(1, 2).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForVerticalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsTrue(result);
      Assert.AreEqual(winnerState, winner);
    }

    [Test]
    public void ValidVerticalWinThreeIsFound()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.X;

      // - - X
      // - - X
      // - - X
      boardState.GetCell(2, 0).State = winnerState;
      boardState.GetCell(2, 1).State = winnerState;
      boardState.GetCell(2, 2).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForVerticalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsTrue(result);
      Assert.AreEqual(winnerState, winner);
    }

    [Test]
    public void ValidHorizontalWinIsNotFoundAsVerticalWin()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.X;

      // X X X
      // - - -
      // - - -
      boardState.GetCell(0, 0).State = winnerState;
      boardState.GetCell(1, 0).State = winnerState;
      boardState.GetCell(2, 0).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForVerticalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsFalse(result);
      Assert.AreEqual(ECellState.Empty, winner);
    }

    [Test]
    public void FoundValidDiagonalWinOne()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.X;

      // X - -
      // - X -
      // - - X
      boardState.GetCell(0, 0).State = winnerState;
      boardState.GetCell(1, 1).State = winnerState;
      boardState.GetCell(2, 2).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForDiagonalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsTrue(result);
      Assert.AreEqual(winnerState, winner);
    }

    [Test]
    public void FoundValidDiagonalTwoOne()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.X;

      // - - X
      // - X -
      // X - -
      boardState.GetCell(2, 0).State = winnerState;
      boardState.GetCell(1, 1).State = winnerState;
      boardState.GetCell(0, 2).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForDiagonalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsTrue(result);
      Assert.AreEqual(winnerState, winner);
    }

    [Test]
    public void InvalidDiagonalWinNotFound()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      const ECellState winnerState = ECellState.X;

      // X X -
      // X X -
      // X - -
      boardState.GetCell(0, 0).State = winnerState;
      boardState.GetCell(1, 0).State = winnerState;
      boardState.GetCell(0, 1).State = winnerState;
      boardState.GetCell(1, 1).State = winnerState;
      boardState.GetCell(0, 2).State = winnerState;

      //Act
      bool result = Utils.BoardStateUtils.CheckForDiagonalWin(boardState, out ECellState winner);

      //Assert
      Assert.IsFalse(result);
      Assert.AreEqual(ECellState.Empty, winner);
    }
  }
}