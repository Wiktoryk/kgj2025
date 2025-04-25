using UnityEngine;
using System.Collections.Generic;

public class InteractionManager : MonoBehaviour
{
    private Transform player;
    private List<Transform> buttons;

    public List<int> chossedIcons;
    void Start()
    {
        player = GameObject.Find("Player").transform;

    }

    void Update()
    {
        if (buttons == null)
        {
            ButtonTest();
        }
        Transform button = isOverButton(player);
        if (Input.GetButtonDown("Fire1") && button != null) {
            button.GetComponent<ButtonController>().Interaction();
            if (!chossedIcons.Contains(button.GetComponent<ButtonController>().icon))
            {
                chossedIcons.Add(button.GetComponent<ButtonController>().icon);
            }
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

    void ButtonTest()
    {
        GameObject.Find("GameController").GetComponent<GameController>().generateButtons();
        buttons = new List<Transform>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Button"))
        {
            buttons.Add(go.transform);
        }
    }
}
