using Data;
using TMPro;
using UnityEngine;

namespace View.GameEnd
{
  public class GameWonView : ViewBase
  {
    [SerializeField]
    private TextMeshProUGUI winnerText;

    public void SetText(ECellState winnerState)
    {
      winnerText.SetText(winnerState.ToString());
    }
  }
}