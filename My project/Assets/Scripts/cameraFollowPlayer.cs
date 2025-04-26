using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = player.position + new Vector3(0,0,-10f);
    }
}
