using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Data
{
  [Serializable]
  public class BoardState : IEnumerable<Cell>
  {
    public readonly int XSize;
    public readonly int YSize;

    public List<Cell> Cells;

    public BoardState(int xSize, int ySize)
    {
      Assert.IsTrue(xSize >= 1);
      XSize = xSize;

      Assert.IsTrue(ySize >= 1);
      YSize = ySize;

      Cells = new List<Cell>(xSize * ySize);

      for (int y = 0; y < ySize; y++)
      for (int x = 0; x < xSize; x++)
        Cells.Add(new Cell(new Vector2Int(x, y)));
    }

    public Cell GetCell(int x, int y)
    {
      Assert.IsTrue(x >= 0 && y >= 0, "x >= 0 && y >= 0");
      Assert.IsTrue(x < XSize && y < YSize, "x < XSize && y < YSize");

      return Cells[YSize * y + x];
    }

    public Cell GetCell(Vector2Int coordinates)
    {
      Assert.IsTrue(coordinates.x >= 0 && coordinates.y >= 0, "coordinates.x >= 0 && coordinates.y >= 0");
      Assert.IsTrue(coordinates.x < XSize && coordinates.y < YSize, "coordinates.x < XSize && coordinates.y < YSize");

      return Cells[YSize * coordinates.y + coordinates.x];
    }

    public IEnumerator<Cell> GetEnumerator()
    {
      return Cells.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}