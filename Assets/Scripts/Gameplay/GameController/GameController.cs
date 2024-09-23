using Data;
using Events;
using Gameplay.UserController;
using Utils;

namespace Gameplay.GameController
{
  public class GameController
  {
    public BoardController BoardController { get; }
    public PlayersManager PlayersManager { get; }
    public HintProvider HintProvider { get; }

    private readonly EGameMode gameMode;

    private bool isGameFinished;

    public GameController(BoardState boardState, IPlayer one, IPlayer two, EGameMode gameMode)
    {
      BoardController = new BoardController(boardState);

      PlayersManager = new PlayersManager(one, two);
      PlayersManager.Initialize(BoardController);
      PlayersManager.Start(one);

      HintProvider = new HintProvider(boardState);

      this.gameMode = gameMode;

      EventBus.OnGameStarted?.Invoke(gameMode);
    }

    public void Tick()
    {
      if (isGameFinished)
        return;

      isGameFinished = CheckIsGameFinished();

      PlayersManager?.Tick();
    }

    public void ReverseLastMove()
    {
      if (BoardController.ReverseLastCommand(out IPlayer issuer))
        PlayersManager.ForcePlayer(issuer);
    }


    public void Restart()
    {
      isGameFinished = false;
      BoardController.Restart();
      PlayersManager.Restart();

      EventBus.OnGameStarted?.Invoke(gameMode);
    }

    private bool CheckIsGameFinished()
    {
      if (BoardStateUtils.CheckForWin(BoardController.BoardState, out ECellState winner))
      {
        EventBus.OnGameWon?.Invoke(winner);
        EventBus.OnGameFinished?.Invoke();

        return true;
      }

      if (BoardStateUtils.CheckDraw(BoardController.BoardState))
      {
        EventBus.OnGameDrawn?.Invoke();
        EventBus.OnGameFinished?.Invoke();

        return true;
      }

      if (PlayersManager.NormalizedRoundTime < 1)
        return false;

      EventBus.OnGameWon?.Invoke(PlayersManager.CurrentPlayer.Team == ECellState.O ? ECellState.X : ECellState.O);
      EventBus.OnGameFinished?.Invoke();

      return true;
    }
  }
}