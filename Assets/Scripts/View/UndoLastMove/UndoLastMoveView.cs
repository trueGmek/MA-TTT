using UnityEngine;
using UnityEngine.UI;

namespace View.UndoLastMove
{
  public class UndoLastMoveView : ViewBase
  {
    [SerializeField]
    private Button button;

    public Button Button => button;
  }
}