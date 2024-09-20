using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace View.BackToMenu
{
  public class BackToMenuView : ViewBase
  {
    [SerializeField]
    private Button button;

    public Button Button => button;
  }
}