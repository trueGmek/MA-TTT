using UnityEngine;

namespace View.BackToMenu
{
  public class BackToMenuViewController : MonoBehaviour
  {
    [SerializeField]
    private BackToMenuView view;


    private void OnEnable()
    {
      view.Button.onClick.AddListener(Gameplay.SceneManager.LoadMenuScene);
    }

    private void OnDisable()
    {
      view.Button.onClick.RemoveListener(Gameplay.SceneManager.LoadMenuScene);
    }
  }
}