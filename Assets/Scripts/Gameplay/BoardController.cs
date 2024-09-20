using System.Collections.Generic;
using Data;
using Data.Command;
using Gameplay.UserController;
using UnityEngine;

namespace Gameplay
{
  public class BoardController
  {
    private struct CommandPacket
    {
      public Command Command;
      public IPlayer Issuer;
    }

    public BoardState BoardState { get; }

    private readonly Stack<CommandPacket> commands;

    public BoardController(BoardState boardState)
    {
      BoardState = boardState;
      commands = new Stack<CommandPacket>();
    }

    public void Restart()
    {
      commands.Clear();
      foreach (Cell cell in BoardState) cell.State = ECellState.Empty;
    }

    public bool IssueCommand(Command command, IPlayer issuer)
    {
      if (command.Execute(BoardState))
      {
        commands.Push(new CommandPacket { Command = command, Issuer = issuer });
        return true;
      }

      Debug.LogError("Failed to execute the command! Reversing");
      command.Reverse(BoardState);

      return false;
    }

    public bool ReverseLastCommand(out IPlayer issuer)
    {
      if (commands.TryPop(out CommandPacket packet))
      {
        packet.Command.Reverse(BoardState);

        issuer = packet.Issuer;
        return true;
      }

      issuer = default;
      return false;
    }
  }
}