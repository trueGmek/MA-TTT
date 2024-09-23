using System.Collections.Generic;
using System.Linq;
using Data;

namespace Utils
{
  public static class BoardStateUtils
  {
    public static bool CheckForWin(BoardState boardState, out ECellState winner)
    {
      return CheckForHorizontalWin(boardState, out winner) ||
             CheckForVerticalWin(boardState, out winner) ||
             CheckForDiagonalWin(boardState, out winner);
    }

    /// <summary>
    /// This method assumes that no win condition has been fulfilled
    /// </summary>
    /// <param name="boardState"></param>
    /// <returns></returns>
    public static bool CheckDraw(BoardState boardState)
    {
      return boardState.GetCellCount(ECellState.Empty) == 0;
    }


    public static bool CheckForVerticalWin(BoardState boardState, out ECellState winner)
    {
      HashSet<ECellState> statesHashSet = new(3);

      for (int x = 0; x < boardState.XSize; x++)
      {
        statesHashSet.Clear();
        for (int y = 0; y < boardState.YSize; y++) statesHashSet.Add(boardState.GetCell(x, y).State);

        if (statesHashSet.Count != 1)
          continue;

        ECellState seenState = statesHashSet.First(_ => true);
        if (seenState == ECellState.Empty)
          continue;

        winner = seenState;
        return true;
      }

      winner = ECellState.Empty;
      return false;
    }

    public static bool CheckForDiagonalWin(BoardState boardState, out ECellState winner)
    {
      HashSet<ECellState> statesHashSet = new(3);

      statesHashSet.Add(boardState.GetCell(0, 0).State);
      statesHashSet.Add(boardState.GetCell(1, 1).State);
      statesHashSet.Add(boardState.GetCell(2, 2).State);

      if (AreAllElementsIdenticalAndNotEmpty(statesHashSet, out winner))
        return true;
      statesHashSet.Clear();

      statesHashSet.Add(boardState.GetCell(0, 2).State);
      statesHashSet.Add(boardState.GetCell(1, 1).State);
      statesHashSet.Add(boardState.GetCell(2, 0).State);

      return AreAllElementsIdenticalAndNotEmpty(statesHashSet, out winner);


      bool AreAllElementsIdenticalAndNotEmpty(HashSet<ECellState> set, out ECellState winner)
      {
        if (set.Count == 1)
        {
          ECellState seenState = set.First(_ => true);
          if (seenState != ECellState.Empty)
          {
            winner = seenState;
            return true;
          }
        }

        winner = ECellState.Empty;
        return false;
      }
    }

    public static bool CheckForHorizontalWin(BoardState boardState, out ECellState winner)
    {
      HashSet<ECellState> statesHashSet = new(3);
      for (int y = 0; y < boardState.YSize; y++)
      {
        statesHashSet.Clear();
        for (int x = 0; x < boardState.XSize; x++) statesHashSet.Add(boardState.GetCell(x, y).State);

        if (statesHashSet.Count != 1)
          continue;

        ECellState seenState = statesHashSet.First(_ => true);
        if (seenState == ECellState.Empty)
          continue;

        winner = seenState;
        return true;
      }

      winner = ECellState.Empty;
      return false;
    }

    private static int GetCellCount(this BoardState board, ECellState state)
    {
      int count = 0;

      foreach (Cell cell in board.Cells)
      {
        if (cell.State == state)
          count++;
      }

      return count;
    }
  }
}