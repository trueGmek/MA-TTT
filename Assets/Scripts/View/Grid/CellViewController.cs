using System;
using Cysharp.Threading.Tasks;
using Data;
using UnityEngine;

namespace View.Grid
{
  public class CellViewController : MonoBehaviour
  {
    [SerializeField]
    private CellView cellView;

    public Vector2Int Coordinates => cell.Coordinates;
    public ECellState State => cell.State;

    private Cell cell;
    private ECellState cachedState;


    private void Update()
    {
      if (cachedState == cell.State)
        return;

      cachedState = cell.State;
      cellView.ControlTargetState(cachedState);
    }

    public void Bind(Cell cell)
    {
      this.cell = cell;
      cachedState = cell.State;

      cellView.ControlTargetState(cachedState);
    }

    public void ShowHint(ECellState mark)
    {
      cellView.ShowHint(mark);
      WaitAndClearHint().Forget();
    }

    private async UniTaskVoid WaitAndClearHint()
    {
      await UniTask.Delay(TimeSpan.FromSeconds(1.5f));
      cellView.ShowHint(ECellState.Empty);
    }
  }
}