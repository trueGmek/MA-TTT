using UnityEngine;
using View;
using View.Grid;

namespace Gameplay
{
  public class GridProvider : MonoBehaviour
  {
    [SerializeField]
    private GridViewController gridViewController;

    [SerializeField]
    private Vector2Int gridSize;
  }
}