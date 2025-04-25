using UnityEngine;
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
        foreach (IconData iconData in icons)
        {
            int icon = iconData.icon;
            GameObject button = Instantiate(buttonPreFab, new Vector3(icon, icon, 0), Quaternion.identity);
            button.SetActive(true);
            button.AddComponent<ButtonController>();
            button.GetComponent<ButtonController>().icon = icon;
        }
    }
}
