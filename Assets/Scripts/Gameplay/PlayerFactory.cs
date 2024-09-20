using System;
using Data;
using Gameplay.UserController;
using Random = UnityEngine.Random;

namespace Gameplay
{
  public struct PlayerPair
  {
    public IPlayer One;
    public IPlayer Two;
  }

  public static class PlayerFactory
  {
    public static PlayerPair GetPlayers(EGameMode gameMode)
    {
      if (gameMode == EGameMode.PlayerVersusComputer)
      {
        if (Random.value >= 0.5)
          return new PlayerPair
          {
            One = new PlayerController(ECellState.O),
            Two = new SimpleBotPlayer(new SimpleBotPlayer.Configuration
              { Delay = TimeSpan.FromSeconds(2.0), Team = ECellState.X })
          };

        return new PlayerPair
        {
          One = new SimpleBotPlayer(new SimpleBotPlayer.Configuration
            { Delay = TimeSpan.FromSeconds(2.0), Team = ECellState.O }),
          Two = new PlayerController(ECellState.X)
        };
      }

      if (gameMode == EGameMode.PlayerVersusPlayer)
        return new PlayerPair
        {
          One = new PlayerController(ECellState.O),
          Two = new PlayerController(ECellState.X)
        };

      throw new NotImplementedException();
    }
  }
}