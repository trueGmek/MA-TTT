using UnityEngine;

namespace Gameplay.Skin
{
  [CreateAssetMenu(menuName = "Skin data")]
  public class SkinDataSO : ScriptableObject
  {
    public bool ShouldLoadSkin { get; set; }
    public Sprite BackgroundTexture { get; set; }
    public Sprite XTexture { get; set; }
    public Sprite OTexture { get; set; }
  }
}