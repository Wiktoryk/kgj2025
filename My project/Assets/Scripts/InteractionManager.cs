using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    private List<Transform> buttons = new List<Transform>();
    public GameObject display;
    public GameObject Particle;
    private Transform player;
    public List<int> chosenIcons = new List<int>();
    
    void Start()
    {
        player = GameObject.Find("Player").transform;

    }

    void Update()
    {
        if (buttons.Count > 0)
        {
            Transform button = isOverButton(player);
            if (button != null && !button.GetComponent<ButtonController>().hasInteracted) 
            {
                player.GetChild(0).gameObject.SetActive(true); 
            }
            else 
            { 
                player.GetChild(0).gameObject.SetActive(false);
            }
            if (Input.GetButtonDown("Fire1") && button != null)
            {
               
                button.GetComponent<ButtonController>().Interaction();
                Instantiate(Particle, button.transform); 
                ButtonController bc = button.GetComponent<ButtonController>();
                if (bc.iconData.used && !chosenIcons.Contains(bc.iconData.icon))
                {
                    chosenIcons.Add(button.GetComponent<ButtonController>().iconData.icon);
                    GameObject go = new GameObject("IconID:" + chosenIcons.Last());
                    go.transform.parent = display.transform;
                    go.AddComponent<Image>();
                    go.GetComponent<Image>().sprite = GameObject.Find("GameController").GetComponent<ResourceManager>().ready[chosenIcons.Last()];
                }
            }
        }
    }
    
    Transform isOverButton(Transform transform)
    {
        foreach (Transform button in buttons)
        {
            if (Vector3.Distance(button.position, transform.position) < 1.0f)
            {
               
                
                if (!button.GetComponent<ButtonController>().hasInteracted)
                {
                    button.GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameController").GetComponent<ResourceManager>().prox[button.GetComponent<ButtonController>().iconData.icon];
                }
                else
                {
                    button.GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameController").GetComponent<ResourceManager>().used[button.GetComponent<ButtonController>().iconData.icon];
                }
                    return button;
            }
            if (!button.GetComponent<ButtonController>().hasInteracted)
            {

                button.GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameController").GetComponent<ResourceManager>().ready[button.GetComponent<ButtonController>().iconData.icon];
            }
            else
            {

                button.GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameController").GetComponent<ResourceManager>().used[button.GetComponent<ButtonController>().iconData.icon];
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
