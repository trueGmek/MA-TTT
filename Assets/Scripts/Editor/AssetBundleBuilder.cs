using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor
{
  public class AssetBundleBuilder : EditorWindow
  {
    private string assetBundleName;
    private Object backgroundTexture;
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
      backgroundTexture = EditorGUILayout.ObjectField("Background", backgroundTexture, typeof(Sprite), false);
      xTexture = EditorGUILayout.ObjectField("X", xTexture, typeof(Sprite), false);
      oTexture = EditorGUILayout.ObjectField("O", oTexture, typeof(Sprite), false);

      if (GUILayout.Button("Build")) Build();
    }

    private void Build()
    {
      if (!Directory.Exists(Application.streamingAssetsPath))
        Directory.CreateDirectory(Application.streamingAssetsPath);

      AssetBundleBuild[] assetBundleBuild =
      {
        new()
        {
          assetNames = new[]
          {
            AssetDatabase.GetAssetPath(backgroundTexture),
            AssetDatabase.GetAssetPath(xTexture),
            AssetDatabase.GetAssetPath(oTexture)
          },
          assetBundleName = assetBundleName
        }
      };

      BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, assetBundleBuild,
        BuildAssetBundleOptions.DeterministicAssetBundle, BuildTarget.StandaloneWindows);
    }
  }
}