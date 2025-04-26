using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public struct IconData
{
    public int icon;

    public IconData(int icon)
    {
        this.icon = icon;
    }
}

public class GameController : MonoBehaviour
{
    public List<IconData> icons = new List<IconData>();
    public List<Vector3> buttonPositions;
    public GameObject buttonPreFab;
    public GameObject chosenItems;
    public GameObject EndText;
    public bool isWin;
    public bool isEnded;
    void Start()
    {

    }

    void Update()
    {
        if (chosenItems.GetComponent<InteractionManager>().chosenIcons.Count == icons.Count && icons.Count > 0)
        {
            checkIcons();
            Debug.Log(isWin);
            if (isWin) 
            {
                EndText.SetActive(true); 
            }
            else
            {
                EndText.transform.GetChild(0).GetComponent<Text>().text = "Przegra³eœ";
                EndText.SetActive(true);
            }
        }
    }

    public void generateButtons()
    {
        icons = GetComponent<ShuffleIcons>().generatedIcons;
        if (buttonPositions.Count != icons.Count)
        {
            throw new Exception("Nie podano wystarczaj¹co pozycji przycisków");
        }
        int counter = 0;
        foreach (IconData iconData in icons)
        {
            int icon = iconData.icon;
            GameObject button = Instantiate(buttonPreFab, buttonPositions[counter++], Quaternion.identity);
            Sprite sprite = Resources.Load<Sprite>("tree runes/" + (icon + 1));
            button.GetComponent<SpriteRenderer>().sprite = sprite;
            button.SetActive(true);
            button.GetComponent<ButtonController>().icon = icon;
            button.tag = "Button";
        }
    }

    public void checkIcons()
    {
        for (int i = 0; i < icons.Count; i++)
        {

            if (chosenItems.GetComponent<InteractionManager>().chosenIcons[i] != icons[i].icon)
            {

                Debug.Log(chosenItems.GetComponent<InteractionManager>().chosenIcons[i] + "==" + icons[i].icon);
                isWin = false;
                return;
            }
        }
        isWin = true;
        return;
    }

}

