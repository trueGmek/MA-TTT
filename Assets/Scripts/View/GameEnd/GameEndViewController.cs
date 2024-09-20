using Data;
using Events;
using Gameplay;
using UnityEngine;

namespace View.GameEnd
{
  public class GameEndViewController : MonoBehaviour
  {
    [SerializeField]
    private GameWonView gameWonView;

    [SerializeField]
    private GameDrawnView gameDrawnView;


    private void Awake()
    {
      gameWonView.gameObject.SetActive(false);
      gameDrawnView.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
      EventBus.OnGameDrawn += OnGameDrawn;
      EventBus.OnGameWon += OnGameWon;
      EventBus.OnGameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
      EventBus.OnGameDrawn -= OnGameDrawn;
      EventBus.OnGameWon -= OnGameWon;
      EventBus.OnGameStarted -= OnGameStarted;
    }

    private void OnGameWon(ECellState winnerState)
    {
      gameWonView.SetVisibility(true, 0.5f);
      gameWonView.SetText(winnerState);
    }

    private void OnGameDrawn()
    {
      gameDrawnView.SetVisibility(true, 0.5f);
    }

    private void OnGameStarted(EGameMode _)
    {
      gameWonView.SetVisibility(false, 0.5f);
      gameDrawnView.SetVisibility(false, 0.5f);
    }
  }
}