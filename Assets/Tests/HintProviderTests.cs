using Data;
using Gameplay;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
  public class HintProviderTests
  {
    private const int X_SIZE = 3, Y_SIZE = 3;

    [Test]
    public void HintProviderTestsPasses()
    {
      Assert.Pass();
    }

    [Test]
    public void HintIsNotNull()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      HintProvider hintProvider = new HintProvider(boardState);
      const ECellState team = ECellState.O;

      //Act
      var hintedCell = hintProvider.GetHint(team);

      //Assert
      Assert.IsNotNull(hintedCell);
    }

    [Test]
    public void HintIsEmpty()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      HintProvider hintProvider = new HintProvider(boardState);
      const ECellState team = ECellState.O;

      //Act
      var hintedCell = hintProvider.GetHint(team);

      //Assert
      Assert.AreEqual(ECellState.Empty, hintedCell.State);
    }

    [Test]
    public void ProvidesAnEmptyHintWithClutteredBoard()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      HintProvider hintProvider = new(boardState);

      foreach (Cell cell in boardState)
      {
        cell.State = ECellState.X;
      }

      //- X X
      //X - X
      //- X -
      boardState.GetCell(0, 0).State = ECellState.Empty;
      boardState.GetCell(1, 1).State = ECellState.Empty;
      boardState.GetCell(2, 2).State = ECellState.Empty;
      boardState.GetCell(0, 2).State = ECellState.Empty;


      //Act
      var hintedCell = hintProvider.GetHint(ECellState.O);

      //Assert
      Assert.AreEqual(ECellState.Empty, hintedCell.State);
    }

    [Test]
    public void ProvidesValidHintWithAlmostFullBoard()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      HintProvider hintProvider = new(boardState);
      Vector2Int emptyCoordinates = new(0, 0);

      foreach (Cell cell in boardState)
      {
        cell.State = ECellState.X;
      }

      //- X X
      //X X X
      //X X X
      boardState.GetCell(emptyCoordinates).State = ECellState.Empty;


      //Act
      var hintedCell = hintProvider.GetHint(ECellState.O);

      //Assert
      Assert.AreEqual(emptyCoordinates, hintedCell.Coordinates);
      Assert.AreEqual(ECellState.Empty, hintedCell.State);
    }
  }
}