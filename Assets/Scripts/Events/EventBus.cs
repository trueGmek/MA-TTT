using System;
using Data;
using Gameplay;

namespace Events
{
  public static class EventBus
  {
    public static Action<ECellState> OnGameWon;
    public static Action OnGameDrawn;
    public static Action<EGameMode> OnGameStarted;
    public static Action OnGameFinished;
  }
}