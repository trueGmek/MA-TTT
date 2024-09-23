using Data;
using Gameplay.UserController;
using UnityEngine;
using UnityEngine.Assertions;

namespace Gameplay.GameController
{
  public class GameControllerProxy : MonoBehaviour
  {
    [SerializeField]
    private GameConfigSO gameConfigSO;

    public BoardController BoardController => GameController.BoardController;
    public PlayersManager PlayersManager => GameController.PlayersManager;
    public HintProvider HintProvider => GameController.HintProvider;
    public GameController GameController { get; private set; }

    private readonly Vector2Int boardSize = new(3, 3);

    private void Awake()
    {
      Assert.IsNotNull(gameConfigSO);

      PlayerPair players = PlayerFactory.GetPlayers(gameConfigSO.gameMode);

      GameController = new GameController(new BoardState(boardSize.x, boardSize.y), players.One, players.Two,
        gameConfigSO.gameMode);
    }

    private void Update()
    {
      GameController.Tick();
    }
  }
}