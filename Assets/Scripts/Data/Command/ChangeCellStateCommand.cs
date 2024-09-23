using UnityEngine;

namespace Data.Command
{
  public class ChangeCellStateCommand : Command
  {
    private readonly Vector2Int coordinates;
    private readonly ECellState newState;

    private ECellState prevState;

    public ChangeCellStateCommand(ECellState state, Vector2Int coordinates)
    {
      this.coordinates = coordinates;
      newState = state;
    }


    public override bool Execute(BoardState board)
    {
      Cell cell = board.GetCell(coordinates);
      prevState = cell.State;
      cell.State = newState;

      return true;
    }

    public override bool Reverse(BoardState board)
    {
      Cell cell = board.GetCell(coordinates);
      cell.State = prevState;
      return true;
    }
  }
}