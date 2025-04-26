using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    private Transform player;
    private List<Transform> buttons = new List<Transform>();

    public List<int> chosenIcons = new List<int>();
    public GameObject display;
    void Start()
    {
        player = GameObject.Find("Player").transform;

    }

    void Update()
    {
        if (buttons.Count > 0)
        {
            Transform button = isOverButton(player);
            if (Input.GetButtonDown("Fire1") && button != null)
            {
               
                button.GetComponent<ButtonController>().Interaction();
                if (!chosenIcons.Contains(button.GetComponent<ButtonController>().icon))
                {
                    chosenIcons.Add(button.GetComponent<ButtonController>().icon);
                    GameObject go = new GameObject("IconID:" + chosenIcons.Last());
                    go.transform.parent = display.transform;
                    go.AddComponent<Image>();
                    Sprite sprite = Resources.Load<Sprite>("runestones/"+(chosenIcons.Last()) + "/" + (chosenIcons.Last()) + "-ready"); 
                    go.GetComponent<Image>().sprite = sprite;
                }
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

    public void ButtonTest()
    {
        GameObject.Find("GameController").GetComponent<GameController>().generateButtons();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Button"))
        {
            buttons.Add(go.transform);
        }
    }
}
