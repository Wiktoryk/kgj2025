using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (isOverButton(player) && Input.GetButtonDown("Fire1")) {
            Debug.Log("test");
        }
    }

    bool isOverButton(Transform transform)
    {
        return true;
    }
}
