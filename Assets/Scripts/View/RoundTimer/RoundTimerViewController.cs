using Events;
using Gameplay;
using Gameplay.GameController;
using UnityEngine;

namespace View.RoundTimer
{
  public class RoundTimerViewController : MonoBehaviour
  {
    [SerializeField]
    private RoundTimerView view;

    [SerializeField]
    private GameControllerProxy gameControllerProxy;

    private void OnEnable()
    {
      EventBus.OnGameFinished += HideView;
      EventBus.OnGameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
      EventBus.OnGameFinished -= HideView;
      EventBus.OnGameStarted -= OnGameStarted;
    }

    private void Update()
    {
      view.SetFill(gameControllerProxy.PlayersManager.NormalizedRoundTime);
    }

    private void HideView()
    {
      view.SetVisibility(false, 0.5f);
    }

    private void OnGameStarted(EGameMode _)
    {
      view.SetVisibility(true, 0.5f);
    }
  }
}