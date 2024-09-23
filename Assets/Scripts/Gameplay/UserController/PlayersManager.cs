using Data;
using UnityEngine.Assertions;
using Time = UnityEngine.Time;

namespace Gameplay.UserController
{
  public class PlayersManager
  {
    public ITeamMember CurrentPlayer => currentPlayer;
    public float NormalizedRoundTime { get; private set; }

    private readonly IPlayer playerOne;
    private readonly IPlayer playerTwo;

    private readonly float roundLength;
    private float lastRoundTimeStamp;


    private IPlayer currentPlayer;

    public PlayersManager(IPlayer playerOne, IPlayer playerTwo, float roundLength = 5f)
    {
      this.playerOne = playerOne;
      this.playerTwo = playerTwo;
      this.roundLength = roundLength;
    }

    public void Initialize(BoardController boardController)
    {
      playerOne.Initialize(boardController);
      playerTwo.Initialize(boardController);
    }

    public void Start(IPlayer player)
    {
      Assert.IsTrue(player == playerOne || player == playerTwo);
      ChangeCurrentPlayer(player);

      lastRoundTimeStamp = Time.timeSinceLevelLoad;
      NormalizedRoundTime = 0f;
    }

    public void Tick()
    {
      Assert.IsNotNull(currentPlayer);
      NormalizedRoundTime = (Time.timeSinceLevelLoad - lastRoundTimeStamp) / roundLength;

      if (currentPlayer.HasMoved)
        NextRound();

      currentPlayer.Tick();
    }

    public void ForcePlayer(IPlayer player)
    {
      ChangeCurrentPlayer(player);
    }

    private void ChangeCurrentPlayer(IPlayer player)
    {
      Assert.IsTrue(player == playerOne || player == playerTwo);
      currentPlayer?.EndTurn();
      currentPlayer = player;
      currentPlayer.StartTurn();

      lastRoundTimeStamp = Time.timeSinceLevelLoad;
    }


    private void NextRound()
    {
      ChangeCurrentPlayer(currentPlayer == playerOne ? playerTwo : playerOne);
      lastRoundTimeStamp = Time.timeSinceLevelLoad;
    }

    public void Restart()
    {
      playerOne.ChangeTeam();
      playerTwo.ChangeTeam();

      ChangeCurrentPlayer(playerOne.Team == ECellState.O ? playerOne : playerTwo);

      lastRoundTimeStamp = Time.timeSinceLevelLoad;
      NormalizedRoundTime = 0f;
    }
  }
}