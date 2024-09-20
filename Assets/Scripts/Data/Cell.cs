using UnityEngine;

namespace Data
{
  public class Cell
  {
    public readonly Vector2Int Coordinates;
    public ECellState State = ECellState.Empty;

    public Cell(Vector2Int coordinates)
    {
      Coordinates = coordinates;
    }
  }
}