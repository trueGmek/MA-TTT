using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Data;
using Data.Command;
using Random = UnityEngine.Random;

namespace Gameplay.UserController
{
  public class SimpleBotPlayer : IPlayer
  {
    public struct Configuration
    {
      public TimeSpan Delay;
      public ECellState Team;
    }

    public bool HasMoved { get; set; }
    public ECellState Team { get; private set; }

    private readonly List<Cell> emptyCells = new();
    private readonly TimeSpan moveDelay;

    private BoardController boardController;
    private CancellationTokenSource cancellationTokenSource;

    public SimpleBotPlayer(Configuration config)
    {
      Team = config.Team;
      moveDelay = config.Delay;
    }

    public void Initialize(BoardController boardController)
    {
      this.boardController = boardController;
    }

    public void StartTurn()
    {
      HasMoved = false;
      cancellationTokenSource = new CancellationTokenSource();
      WaitAndMakeMove(cancellationTokenSource.Token).Forget();
    }

    public void Tick()
    {
    }

    public void EndTurn()
    {
      cancellationTokenSource.Cancel();
    }

    public void ChangeTeam()
    {
      Team = Team == ECellState.X ? ECellState.O : ECellState.X;
    }


    private async UniTaskVoid WaitAndMakeMove(CancellationToken cancellationToken = default)
    {
      if (moveDelay != TimeSpan.Zero)
        await UniTask.Delay(moveDelay, cancellationToken: cancellationToken);


      emptyCells.Clear();

      foreach (Cell cell in boardController.BoardState)
        if (cell.State == ECellState.Empty)
          emptyCells.Add(cell);

      Cell emptyCell = emptyCells[Random.Range(0, emptyCells.Count)];

      if (cancellationToken.IsCancellationRequested)
        return;

      boardController.IssueCommand(new ChangeCellStateCommand(Team, emptyCell.Coordinates), this);
      HasMoved = true;
    }
  }
}