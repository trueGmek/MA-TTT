using System;
using System.Linq;
using Data;
using Gameplay;
using Gameplay.UserController;
using NUnit.Framework;

namespace Tests
{
  public class PlayerManagerTests
  {
    private const int X_SIZE = 3, Y_SIZE = 3;

    private readonly SimpleBotPlayer.Configuration playerOneConfig = new()
      { Delay = TimeSpan.Zero, Team = ECellState.O };

    private readonly SimpleBotPlayer.Configuration playerTwoConfig = new()
      { Delay = TimeSpan.Zero, Team = ECellState.X };

    [Test]
    public void PlayerManageTestsPasses()
    {
      Assert.Pass();
    }

    [Test]
    public void StartGameWithTwoBots()
    {
      //Arrange
      BoardController boardController = new(new BoardState(X_SIZE, Y_SIZE));
      SimpleBotPlayer playerOne = new(playerOneConfig);
      SimpleBotPlayer playerTwo = new(playerTwoConfig);
      PlayersManager manager = new(playerOne, playerTwo);
      manager.Initialize(boardController);

      //Act
      manager.Start(playerOne);

      //Assert
      Assert.IsFalse(IsBoardEmpty(boardController));
    }

    [Test]
    public void RunGameForOneFrameTwoFieldsShouldChange()
    {
      //Arrange
      BoardController boardController = new(new BoardState(X_SIZE, Y_SIZE));
      SimpleBotPlayer playerOne = new(playerOneConfig);
      SimpleBotPlayer playerTwo = new(playerTwoConfig);
      PlayersManager manager = new(playerOne, playerTwo);
      manager.Initialize(boardController);

      //Act
      manager.Start(playerOne);
      manager.Tick();

      //Assert
      Assert.AreEqual(1, GetNumberOfCellsWithState(boardController, ECellState.O));
      Assert.AreEqual(1, GetNumberOfCellsWithState(boardController, ECellState.X));
      Assert.AreEqual(7, GetNumberOfCellsWithState(boardController, ECellState.Empty));
    }

    [Test]
    public void RunGameForTwoFramesThreeFieldsShouldChange()
    {
      //Arrange
      BoardController boardController = new(new BoardState(X_SIZE, Y_SIZE));
      SimpleBotPlayer playerOne = new(playerOneConfig);
      SimpleBotPlayer playerTwo = new(playerTwoConfig);
      PlayersManager manager = new(playerOne, playerTwo);
      manager.Initialize(boardController);

      //Act
      manager.Start(playerOne);
      manager.Tick();
      manager.Tick();

      //Assert
      Assert.AreEqual(2, GetNumberOfCellsWithState(boardController, ECellState.O));
      Assert.AreEqual(1, GetNumberOfCellsWithState(boardController, ECellState.X));
      Assert.AreEqual(6, GetNumberOfCellsWithState(boardController, ECellState.Empty));
    }

    [Test]
    public void RunGameForThreeFramesFourFieldsShouldChange()
    {
      //Arrange
      BoardController boardController = new(new BoardState(X_SIZE, Y_SIZE));
      SimpleBotPlayer playerOne = new(playerOneConfig);
      SimpleBotPlayer playerTwo = new(playerTwoConfig);
      PlayersManager manager = new(playerOne, playerTwo);
      manager.Initialize(boardController);

      //Act
      manager.Start(playerOne);
      manager.Tick();
      manager.Tick();
      manager.Tick();

      //Assert
      Assert.AreEqual(2, GetNumberOfCellsWithState(boardController, ECellState.O));
      Assert.AreEqual(2, GetNumberOfCellsWithState(boardController, ECellState.X));
      Assert.AreEqual(5, GetNumberOfCellsWithState(boardController, ECellState.Empty));
    }

    [Test]
    public void RunGameInALoop()
    {
      //Arrange
      BoardController boardController = new(new BoardState(X_SIZE, Y_SIZE));
      SimpleBotPlayer playerOne = new(playerOneConfig);
      SimpleBotPlayer playerTwo = new(playerTwoConfig);
      PlayersManager manager = new(playerOne, playerTwo);
      manager.Initialize(boardController);

      //Act
      manager.Start(playerOne);

      for (int i = 0; i < 8; i++)
      {
        manager.Tick();
      }

      //Assert
      Assert.AreEqual(5, GetNumberOfCellsWithState(boardController, ECellState.O));
      Assert.AreEqual(4, GetNumberOfCellsWithState(boardController, ECellState.X));
      Assert.AreEqual(0, GetNumberOfCellsWithState(boardController, ECellState.Empty));
    }

    private bool IsBoardEmpty(BoardController controller)
    {
      return X_SIZE * Y_SIZE == GetNumberOfCellsWithState(controller, ECellState.Empty);
    }

    private int GetNumberOfCellsWithState(BoardController controller, ECellState state)
    {
      return controller.BoardState.Count(cell => cell.State == state);
    }
  }
}