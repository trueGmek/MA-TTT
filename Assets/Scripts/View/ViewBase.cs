using PrimeTween;
using UnityEngine;

namespace View
{
  [RequireComponent(typeof(CanvasGroup))]
  public abstract class ViewBase : MonoBehaviour
  {
    public CanvasGroup CanvasGroup { get; private set; }

    private void Awake()
    {
      CanvasGroup = GetComponent<CanvasGroup>();
    }

    public void SetVisibility(bool isVisible)
    {
      if (gameObject.activeSelf == isVisible)
        return;

      CanvasGroup.alpha = isVisible ? 1 : 0f;
      gameObject.SetActive(isVisible);
    }

    public void SetVisibility(bool isVisible, float time)
    {
      if (gameObject == null || gameObject.activeSelf == isVisible)
        return;

      float targetAlpha = isVisible ? 1 : 0f;
      Sequence sequence = Sequence.Create();

      gameObject.SetActive(true);
      sequence.Chain(Tween.Alpha(CanvasGroup, targetAlpha, time));

      if (isVisible == false) sequence.ChainCallback(() => gameObject.SetActive(false));
    }
  }
}