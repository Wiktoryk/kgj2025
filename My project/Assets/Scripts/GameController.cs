using UnityEngine;
using System;
using System.Collections.Generic;

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
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void generateButtons()
    {
        icons = GetComponent<ShuffleIcons>().generatedIcons;
        if (buttonPositions.Count!=icons.Count)
        {
            throw new Exception("Nie podano wystarczaj¹co pozycji przycisków");
        }
        int counter = 0;
        foreach (IconData iconData in icons)
        {
            int icon = iconData.icon;
            GameObject button = Instantiate(buttonPreFab, buttonPositions[counter++], Quaternion.identity);
            button.SetActive(true);
            button.AddComponent<ButtonController>();
            button.GetComponent<ButtonController>().icon = icon;
        }
    }
}
