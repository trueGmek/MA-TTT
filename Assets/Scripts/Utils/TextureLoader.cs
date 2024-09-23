using System;
using Gameplay.Skin;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
  [RequireComponent(typeof(Image))]
  public class TextureLoader : MonoBehaviour
  {
    [SerializeField]
    private SkinDataSO skinDataSO;

    [SerializeField]
    private EAssetBundlePosition whatToLoad;

    private void Start()
    {
      if (skinDataSO == null || skinDataSO.ShouldLoadSkin == false || whatToLoad == EAssetBundlePosition.Nothing)
        return;

      Sprite sprite = whatToLoad switch
      {
        EAssetBundlePosition.O => skinDataSO.OTexture,
        EAssetBundlePosition.X => skinDataSO.XTexture,
        EAssetBundlePosition.Background => skinDataSO.BackgroundTexture,
        EAssetBundlePosition.Nothing => null,
        _ => throw new ArgumentOutOfRangeException()
      };

      GetComponent<Image>().sprite = sprite;
    }
  }
}