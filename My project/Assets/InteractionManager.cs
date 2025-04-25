using UnityEngine;
using Unity.Core;
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
        Transform button = isOverButton(player).Value;
        if (Input.GetButtonDown("Fire1") && button != null) {
            button.GetComponent<ButtonController>().Interaction();
        }
    }

    Optional<Transform> isOverButton(Transform transform)
    {
        foreach (Transform button in buttons)
        {
            if (Physics.OverlapSphere(transform, button))
            {
                return button;
            }
        }
        return null;
    }
}
