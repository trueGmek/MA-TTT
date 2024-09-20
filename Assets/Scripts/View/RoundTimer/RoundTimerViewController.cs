using Events;
using Gameplay;
using UnityEngine;

namespace View.RoundTimer
{
  public class RoundTimerViewController : MonoBehaviour
  {
    [SerializeField]
    private RoundTimerView view;

    [SerializeField]
    private GameController gameController;

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
      view.SetFill(gameController.PlayersManager.NormalizedRoundTime);
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