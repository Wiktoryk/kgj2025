using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class WallControl : MonoBehaviour
{
    public GameObject walls;
    public bool isActive=false;
    void Update()
    {
        foreach (Transform wall in walls.transform)
        {
            wall.gameObject.SetActive(isActive);
        }
    }
}
