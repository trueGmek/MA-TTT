using System.Collections.Generic;
using Data;
using Data.Command;
using UnityEngine;
using UnityEngine.EventSystems;
using View.Grid;

namespace Gameplay.UserController
{
  public class PlayerController : IPlayer
  {
    public bool HasMoved { get; private set; }
    public ECellState Team { get; private set; }

    private PointerEventData EventData { get; } = new(EventSystem.current);

    private readonly List<RaycastResult> results = new();

    private BoardController boardController;

    public PlayerController(ECellState team)
    {
      Team = team;
    }

    public void Initialize(BoardController boardController)
    {
      this.boardController = boardController;
    }


    public void StartTurn()
    {
      HasMoved = false;
    }

    public void Tick()
    {
      if (Input.GetKeyDown(KeyCode.Mouse0) == false)
        return;

      EventData.position = Input.mousePosition;
      EventSystem.current.RaycastAll(EventData, results);

      foreach (RaycastResult result in results)
      {
        CellViewController cellViewController = result.gameObject.GetComponentInParent<CellViewController>();
        if (cellViewController == null)
          continue;

        if (cellViewController.State != ECellState.Empty)
          continue;

        boardController.IssueCommand(new ChangeCellStateCommand(Team, cellViewController.Coordinates), this);
        HasMoved = true;
      }
    }

    public void EndTurn()
    {
    }

    public void ChangeTeam()
    {
      Team = Team == ECellState.X ? ECellState.O : ECellState.X;
    }
  }
}