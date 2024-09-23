using System.IO;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;

namespace Gameplay.Skin
{
  public class SkinProvider : MonoBehaviour
  {
    [SerializeField]
    private SkinDataSO skinDataSO;

    private void Awake()
    {
      Assert.IsNotNull(skinDataSO);
      skinDataSO.ShouldLoadSkin = false;
    }

    public void LoadSkin(string assetBundleName)
    {
      string path = Path.Combine(Application.streamingAssetsPath, assetBundleName);
      AssetBundle assetBundle = AssetBundleManager.Load(path);

      if (assetBundle == null)
      {
        Debug.LogError($"Failed to load! Asset bundle: {assetBundleName} does not exist!");
        return;
      }

      skinDataSO.ShouldLoadSkin = true;

      var textAsset = assetBundle.LoadAsset<TextAsset>($"{assetBundleName}.json");
      SkinMetadata metadata = JsonUtility.FromJson<SkinMetadata>(textAsset.text);

      skinDataSO.BackgroundTexture = assetBundle.LoadAsset<Sprite>(metadata.backgroundTexture);
      skinDataSO.XTexture = assetBundle.LoadAsset<Sprite>(metadata.xTexture);
      skinDataSO.OTexture = assetBundle.LoadAsset<Sprite>(metadata.oTexture);

      assetBundle.Unload(false);
    }
  }
}