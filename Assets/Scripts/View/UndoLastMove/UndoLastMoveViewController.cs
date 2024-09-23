using Events;
using Gameplay;
using Gameplay.GameController;
using UnityEngine;

namespace View.UndoLastMove
{
  public class UndoLastMoveViewController : MonoBehaviour
  {
    [SerializeField]
    private UndoLastMoveView view;

    [SerializeField]
    private GameControllerProxy gameControllerProxy;

    private void OnEnable()
    {
      view.Button.onClick.AddListener(ReverseMove);
      EventBus.OnGameFinished += HideView;
      EventBus.OnGameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
      view.Button.onClick.RemoveListener(ReverseMove);
      EventBus.OnGameFinished -= HideView;
      EventBus.OnGameStarted -= OnGameStarted;
    }

    private void ReverseMove()
    {
      gameControllerProxy.GameController.ReverseLastMove();
    }

    private void HideView()
    {
      view.SetVisibility(false, 0.5f);
    }

    private void OnGameStarted(EGameMode gameMode)
    {
      if (gameMode == EGameMode.PlayerVersusComputer)
        view.SetVisibility(true, 0.5f);
      else
        view.SetVisibility(false);
    }
  }
}