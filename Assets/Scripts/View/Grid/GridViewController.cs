using System.Collections.Generic;
using Data;
using Gameplay;
using UnityEngine;

namespace View.Grid
{
  public class GridViewController : MonoBehaviour
  {
    [SerializeField]
    private GridView gridView;

    [SerializeField]
    private GameController gameController;

    private CellViewController[] cellControllers;
    private readonly Dictionary<Cell, CellViewController> cellsOverControllers = new();
    private CellViewController hintedView;


    private void Awake()
    {
      cellControllers = GetComponentsInChildren<CellViewController>();
    }

    private void Start()
    {
      Bind(gameController.BoardController.BoardState);
    }

    public void Show()
    {
      gridView.SetVisibility(true, 1f);
    }

    public void ShowHint(Cell cell, ECellState mark)
    {
      hintedView = cellsOverControllers[cell];
      hintedView.ShowHint(mark);
    }


    private void Bind(BoardState boardState)
    {
      int i = 0;
      foreach (Cell cell in boardState)
      {
        cellsOverControllers.Add(cell, cellControllers[i]);
        cellControllers[i++].Bind(cell);
      }
    }
  }
}