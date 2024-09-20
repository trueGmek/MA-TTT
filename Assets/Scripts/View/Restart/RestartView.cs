using UnityEngine;
using UnityEngine.UI;

namespace View.Restart
{
  public class RestartView : ViewBase
  {
    [SerializeField]
    private Button button;

    public Button Button => button;
  }
}