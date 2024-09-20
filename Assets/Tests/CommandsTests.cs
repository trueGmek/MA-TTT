using Data;
using Data.Command;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
  public class CommandsTests
  {
    private const int X_SIZE = 3, Y_SIZE = 3;

    [Test]
    public void CommandsSimplePasses()
    {
      //Arrange
      //Act
      //Assert
      Assert.Pass();
    }

    [Test]
    public void ChangeStateOfOneCellToX()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      Vector2Int coordinates = new(0, 0);
      const ECellState newState = ECellState.X;
      ChangeCellStateCommand command = new(newState, coordinates);

      //Act
      command.Execute(boardState);

      //Assert
      Assert.AreEqual(newState, boardState.GetCell(coordinates).State);
    }

    [Test]
    public void ChangeStateOfOneCellToO()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      Vector2Int coordinates = new(1, 1);
      const ECellState newState = ECellState.O;
      ChangeCellStateCommand command = new(newState, coordinates);

      //Act
      command.Execute(boardState);

      //Assert
      Assert.AreEqual(newState, boardState.GetCell(coordinates).State);
    }


    [Test]
    public void ExecuteCommandReverseItAssertThatNothingChanged()
    {
      //Arrange
      BoardState boardState = new(X_SIZE, Y_SIZE);
      Vector2Int coordinates = new(1, 1);
      ChangeCellStateCommand command = new(ECellState.O, coordinates);
      ECellState cachedState = boardState.GetCell(coordinates).State;

      //Act
      command.Execute(boardState);
      command.Reverse(boardState);

      //Assert
      Assert.AreEqual(cachedState, boardState.GetCell(coordinates).State);
    }
  }
}