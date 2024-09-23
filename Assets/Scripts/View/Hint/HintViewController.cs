using Data;
using Events;
using Gameplay;
using Gameplay.GameController;
using UnityEngine;
using View.Grid;

namespace View.Hint
{
  public class HintViewController : MonoBehaviour
  {
    [SerializeField]
    private GameControllerProxy gameControllerProxy;

    [SerializeField]
    private GridViewController gridViewController;

    [SerializeField]
    private HintView view;

    private void OnEnable()
    {
      view.Button.onClick.AddListener(ShowHint);

      EventBus.OnGameFinished += HideView;
      EventBus.OnGameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
      view.Button.onClick.RemoveListener(ShowHint);
      EventBus.OnGameFinished -= HideView;
      EventBus.OnGameStarted -= OnGameStarted;
    }

    private void ShowHint()
    {
      ECellState currentTeam = gameControllerProxy.PlayersManager.CurrentPlayer.Team;
      gridViewController.ShowHint(gameControllerProxy.HintProvider.GetHint(currentTeam), currentTeam);
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