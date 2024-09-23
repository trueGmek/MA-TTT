using Gameplay.Skin;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
  public class ReskinViewController : MonoBehaviour
  {
    [SerializeField]
    private Button button;

    [SerializeField]
    private SkinProvider skinProvider;

    [SerializeField]
    private TMP_InputField inputField;

    private void OnEnable()
    {
      button.onClick.AddListener(SetName);
    }

    private void OnDisable()
    {
      button.onClick.RemoveListener(SetName);
    }

    private void SetName()
    {
      skinProvider.LoadSkin(inputField.text);
    }
  }
}