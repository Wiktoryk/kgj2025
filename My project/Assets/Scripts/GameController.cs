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
    public List<IconData> icons;
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
        if (chosenItems.GetComponent<InteractionManager>().chosenIcons.Count == icons.Count)
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
            if (icon % 3 == 0)
            {
                button.GetComponent<SpriteRenderer>().color = new Color((float)icon / 10, 0, 0);
            }
            else if (icon % 3 == 1)
            {
                button.GetComponent<SpriteRenderer>().color = new Color(0, (float)icon / 10, 0);
            }
            else if (icon % 3 == 2)
            {
                button.GetComponent<SpriteRenderer>().color = new Color(0, 0, (float)icon / 10);
            }
            button.SetActive(true);
            button.AddComponent<ButtonController>();
            button.GetComponent<ButtonController>().icon = icon;
        }
    }

    public void checkIcons()
    {
        for (int i = 0; i < icons.Count; i++)
        {

            Debug.Log(chosenItems.GetComponent<InteractionManager>().chosenIcons[i] + "==" + icons[i].icon);

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

