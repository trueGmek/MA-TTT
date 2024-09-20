using System;
using Data;
using UnityEngine;

namespace View.Grid
{
  public class CellView : ViewBase
  {
    [SerializeField] private GameObject xTarget;
    [SerializeField] private GameObject oTarget;

    [SerializeField] private GameObject xHint;
    [SerializeField] private GameObject oHint;

    private void Start()
    {
      oTarget.SetActive(false);
      xTarget.SetActive(false);

      oHint.SetActive(false);
      xHint.SetActive(false);
    }

    public void ShowHint(ECellState state)
    {
      xHint.SetActive(false);
      oHint.SetActive(false);

      switch (state)
      {
        case ECellState.Empty:
          break;
        case ECellState.X:
          xHint.SetActive(true);
          break;
        case ECellState.O:
          oHint.SetActive(true);
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(state), state, null);
      }
    }

    public void ControlTargetState(ECellState state)
    {
      xTarget.SetActive(false);
      oTarget.SetActive(false);

      switch (state)
      {
        case ECellState.Empty:
          break;
        case ECellState.X:
          xTarget.SetActive(true);
          break;
        case ECellState.O:
          oTarget.SetActive(true);
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(state), state, null);
      }
    }
  }
}