using UnityEngine;
using UnityEngine.UI;

namespace View.Hint
{
  public class HintView : ViewBase
  {
    [SerializeField]
    private Button button;

    public Button Button => button;
  }
}