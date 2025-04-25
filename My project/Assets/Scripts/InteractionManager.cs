using UnityEngine;
using System.Collections.Generic;

public class InteractionManager : MonoBehaviour
{
    private Transform player;
    private List<Transform> buttons;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        buttons = new List<Transform>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Button"))
        {
            buttons.Add(go.transform);
        }
    }

    void Update()
    {
        Transform button = isOverButton(player);
        if (Input.GetButtonDown("Fire1") && button != null) {
            button.GetComponent<ButtonController>().Interaction();
        }
    }
    
    Transform? isOverButton(Transform transform)
    {
        foreach (Transform button in buttons)
        {
            if (Vector3.Distance(button.position, transform.position) < 1.0f)
            {
                return button;
            }
        }
        return null;
    }
}
