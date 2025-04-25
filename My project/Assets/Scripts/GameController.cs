using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public List<int> icons;
    public GameObject buttonPreFab;
    void Start()
    {
        icons.Add(1);
        icons.Add(2);
        generateButtons();
    }

    void Update()
    {
        
    }

    void generateButtons()
    {
        foreach (int icon in icons)
        {
            GameObject button = Instantiate(buttonPreFab, new Vector3(icon, icon, 0), Quaternion.identity);
            button.SetActive(true);
            button.AddComponent<ButtonController>();
            button.GetComponent<ButtonController>().icon = icon;
        }
    }
}
