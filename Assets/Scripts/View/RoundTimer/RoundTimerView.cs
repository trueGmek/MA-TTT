using UnityEngine;
using UnityEngine.UI;

namespace View.RoundTimer
{
  public class RoundTimerView : ViewBase
  {
    [SerializeField]
    private Image image;

    public void SetFill(float value)
    {
      image.fillAmount = Mathf.Clamp01(value);
    }
  }
}