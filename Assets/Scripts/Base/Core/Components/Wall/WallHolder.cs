using System.Collections.Generic;
using UnityEngine;
using WB.Base.Core.Components.Wall.WallComponent;

public class WallHolder : MonoBehaviour
{
    #region List
    private List<Transform> _walls=new List<Transform>();
    #endregion

    #region
    [SerializeField] private Transform _transformPoint;
    #endregion

    private void Start()
    {
        foreach (Transform child in transform)
        {
            WallComponent wallComponent = child.GetComponent<WallComponent>();
            if (wallComponent != null)
            {
                _walls.Add(child);
            }
        }
    }

    public void ReLoad(Transform character)
    {
        foreach (Transform wall in _walls)
        {
            wall.gameObject.SetActive(true);
        }
        character.transform.position = _transformPoint.position;
    }
}
