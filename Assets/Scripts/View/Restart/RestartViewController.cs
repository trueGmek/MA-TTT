using Gameplay.GameController;
using UnityEngine;

namespace View.Restart
{
  public class RestartViewController : MonoBehaviour
  {
    [SerializeField]
    private RestartView view;

    [SerializeField]
    private GameControllerProxy gameControllerProxy;

    private void OnEnable()
    {
      view.Button.onClick.AddListener(Restart);
    }

    private void OnDisable()
    {
      view.Button.onClick.RemoveListener(Restart);
    }

    private void Restart()
    {
      gameControllerProxy.GameController.Restart();
    }
  }
}