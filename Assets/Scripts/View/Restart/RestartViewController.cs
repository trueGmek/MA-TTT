using Gameplay;
using UnityEngine;

namespace View.Restart
{
  public class RestartViewController : MonoBehaviour
  {
    [SerializeField]
    private RestartView view;

    [SerializeField]
    private GameController gameController;

    private void OnEnable()
    {
      view.Button.onClick.AddListener(gameController.Restart);
    }

    private void OnDisable()
    {
      view.Button.onClick.RemoveListener(gameController.Restart);
    }
  }
}