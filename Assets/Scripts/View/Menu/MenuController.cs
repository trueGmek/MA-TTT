using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace View.Menu
{
  public class MenuController : MonoBehaviour
  {
    [SerializeField]
    private GameModeDropdownView gameModeDropdownView;

    [SerializeField]
    private Button startGameButton;

    [SerializeField]
    private Button exitButton;

    [SerializeField]
    private GameConfigSO gameConfigSO;

    private void OnEnable()
    {
      startGameButton.onClick.AddListener(StartGame);
      exitButton.onClick.AddListener(Application.Quit);
    }

    private void OnDisable()
    {
      startGameButton.onClick.RemoveListener(StartGame);
      exitButton.onClick.RemoveListener(Application.Quit);
    }

    private void StartGame()
    {
      gameConfigSO.gameMode = gameModeDropdownView.GetCurrentValue();
      SceneManager.LoadGameplayScene();
    }
  }
}