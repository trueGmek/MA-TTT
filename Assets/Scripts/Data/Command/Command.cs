namespace Data.Command
{
  public abstract class Command
  {
    public abstract bool Execute(BoardState board);
    public abstract bool Reverse(BoardState board);
  }
}