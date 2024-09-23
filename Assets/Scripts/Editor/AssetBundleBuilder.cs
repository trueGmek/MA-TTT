using System.IO;
using Gameplay.Skin;
using UnityEditor;
using UnityEngine;

namespace Editor
{
  public class AssetBundleBuilder : EditorWindow
  {
    private string assetBundleName;
    private Object backgroundSprite;
    private Object xTexture;
    private Object oTexture;

    [MenuItem("Window/Asset Bundle Builder")]
    public static void ShowWindow()
    {
      GetWindow(typeof(AssetBundleBuilder));
    }

    private void OnGUI()
    {
      GUILayout.Label("Data");

      assetBundleName = EditorGUILayout.TextField("Name", assetBundleName);
      backgroundSprite = EditorGUILayout.ObjectField("Background", backgroundSprite, typeof(Sprite), false);
      xTexture = EditorGUILayout.ObjectField("X", xTexture, typeof(Sprite), false);
      oTexture = EditorGUILayout.ObjectField("O", oTexture, typeof(Sprite), false);

      if (GUILayout.Button("Build"))
        Build();
    }

    private void Build()
    {
      if (!Directory.Exists(Application.streamingAssetsPath))
        Directory.CreateDirectory(Application.streamingAssetsPath);

      string metadataPath = CreateMetaData();

      AssetBundleBuild[] assetBundleBuild =
      {
        new()
        {
          assetNames = new[]
          {
            AssetDatabase.GetAssetPath(backgroundSprite),
            AssetDatabase.GetAssetPath(xTexture),
            AssetDatabase.GetAssetPath(oTexture),
            Path.Combine("Assets/", Path.GetRelativePath(Application.dataPath, metadataPath))
          },
          assetBundleName = assetBundleName
        }
      };

      BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, assetBundleBuild,
        BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.ForceRebuildAssetBundle,
        BuildTarget.StandaloneWindows);
    }

    private string CreateMetaData()
    {
      SkinMetadata metadata = new()
      {
        backgroundTexture = AssetDatabase.GetAssetPath(backgroundSprite),
        xTexture = AssetDatabase.GetAssetPath(xTexture),
        oTexture = AssetDatabase.GetAssetPath(oTexture)
      };

      string metadataFilePath = Path.Combine(Application.dataPath, "Resources", $"{assetBundleName}.json");
      File.WriteAllText(metadataFilePath, JsonUtility.ToJson(metadata, true));

      return metadataFilePath;
    }
  }
}