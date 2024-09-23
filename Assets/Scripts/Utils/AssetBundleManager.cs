using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Utils
{
  public static class AssetBundleManager
  {
    private static readonly Dictionary<string, AssetBundle> LoadedBundles = new();


    public static AssetBundle Load(string path)
    {
      if (File.Exists(path) == false)
        return null;

      if (LoadedBundles.TryGetValue(path, out AssetBundle load))
        return load;

      AssetBundle assetBundle = AssetBundle.LoadFromFile(path);

      LoadedBundles.Add(path, assetBundle);
      return assetBundle;
    }
  }
}