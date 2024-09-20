using System.IO;
using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
  [RequireComponent(typeof(Image))]
  public class TextureLoader : MonoBehaviour
  {
    [SerializeField]
    private SkinConfigSO skinConfigSO;

    [SerializeField]
    private EAssetBundlePosition whatToLoad;

    private void Awake()
    {
      string path = Path.Combine(Application.streamingAssetsPath, skinConfigSO.assetBundleName);

      AssetBundle assetBundle = AssetBundleManager.Load(path);
      if (assetBundle == null)
        return;

      Sprite sprite = assetBundle.LoadAsset<Sprite>(assetBundle.GetAllAssetNames()[(int)whatToLoad]);

      GetComponent<Image>().sprite = sprite;
    }
  }
}