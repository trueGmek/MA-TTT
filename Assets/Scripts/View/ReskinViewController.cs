using Gameplay;
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
    private TMP_InputField inputField;

    [SerializeField]
    private SkinConfigSO skinConfigSO;

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
      skinConfigSO.assetBundleName = inputField.text;
    }
  }
}