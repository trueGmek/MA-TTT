using UnityEngine;

namespace Gameplay
{
  [CreateAssetMenu(menuName = "Game Config")]
  public class GameConfigSO : ScriptableObject
  {
    public EGameMode gameMode;
  }
}