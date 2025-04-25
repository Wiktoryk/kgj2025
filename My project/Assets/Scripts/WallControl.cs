using Unity.VisualScripting;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    public GameObject wall;
    public bool isActive=false;
    void Update()
    {
        wall.SetActive(isActive);
    }
}
