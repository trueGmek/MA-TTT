namespace Gameplay
{
  public static class SceneManager
  {
    public static void LoadGameplayScene()
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public static void LoadMenuScene()
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
  }
}