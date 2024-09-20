using Data;
using Events;
using Gameplay.UserController;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;

namespace Gameplay
{
  public class GameController : MonoBehaviour
  {
    [SerializeField]
    private GameConfigSO gameConfigSO;

    public BoardController BoardController { get; private set; }
    public PlayersManager PlayersManager { get; private set; }
    public HintProvider HintProvider { get; private set; }

    private readonly Vector2Int boardSize = new(3, 3);

    private bool isGameFinished;

    private void Awake()
    {
      Assert.IsNotNull(gameConfigSO);

      PlayerPair players = PlayerFactory.GetPlayers(gameConfigSO.gameMode);
      StartGame(new BoardState(boardSize.x, boardSize.y), players.One, players.Two);
    }

    private void Update()
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

    private void StartGame(BoardState boardState, IPlayer one, IPlayer two)
    {
      BoardController = new BoardController(boardState);

      PlayersManager = new PlayersManager(one, two);
      PlayersManager.Initialize(BoardController);
      PlayersManager.Start(one);

      HintProvider = new HintProvider(boardState);

      EventBus.OnGameStarted?.Invoke(gameConfigSO.gameMode);
    }

    public void Restart()
    {
      isGameFinished = false;
      BoardController.Restart();
      PlayersManager.Restart();

      EventBus.OnGameStarted?.Invoke(gameConfigSO.gameMode);
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