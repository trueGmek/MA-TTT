namespace Gameplay.UserController
{
  public interface IPlayer : ITeamMember
  {
    public bool HasMoved { get; }

    public void Initialize(BoardController boardController);
    public void StartTurn();
    public void Tick();
    public void EndTurn();

    public void ChangeTeam();
  }
}