using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;

namespace Gameplay
{
  public class HintProvider
  {
    private BoardState boardState;

    public HintProvider(BoardState boardState)
    {
      this.boardState = boardState;
    }

    public Cell GetHint(ECellState team)
    {
      List<Cell> emptyCells = boardState.Where(cell => cell.State == ECellState.Empty).ToList();

      return emptyCells[Random.Range(0, emptyCells.Count)];
    }
  }
}