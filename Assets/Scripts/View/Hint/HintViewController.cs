using Data;
using Events;
using Gameplay;
using UnityEngine;
using View.Grid;

namespace View.Hint
{
  public class HintViewController : MonoBehaviour
  {
    [SerializeField]
    private GameController gameController;

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
      ECellState currentTeam = gameController.PlayersManager.CurrentPlayer.Team;
      gridViewController.ShowHint(gameController.HintProvider.GetHint(currentTeam), currentTeam);
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