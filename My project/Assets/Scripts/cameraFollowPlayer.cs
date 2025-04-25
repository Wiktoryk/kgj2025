using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    void Start()
    {

    }

    void Update()
    {
        transform.position = player.position + new Vector3(0,0,-10f);
    }
}
