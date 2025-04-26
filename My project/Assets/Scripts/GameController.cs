using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public List<int> icons = new List<int>();
    public List<Vector3> buttonPositions;
    public GameObject buttonPreFab;
    public GameObject chosenItems;
    public GameObject EndText;
    public bool isWin;
    public bool isEnded;
    void Start()
    {
        isWin = false; isEnded = false;
        Cursor.visible = false;
    }

    void Update()
    {
        if (chosenItems.GetComponent<InteractionManager>().chosenIcons.Count == icons.Count && icons.Count > 0)
        {
            checkIcons();
            isEnded = true;
            
        }
        if (isEnded)
        {
            if (isWin)
            {
                EndText.SetActive(true);
                if (Input.anyKeyDown)
                {
                    if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                    else
                    {
                        SceneManager.LoadScene("Start");
                    }
                }

            }
            else
            {
                EndText.transform.GetChild(0).GetComponent<Text>().text = "Przegra³eœ";
                EndText.SetActive(true);
                if (Input.anyKeyDown)
                {
                    new WaitForSecondsRealtime(50);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name) ;
                }
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
        int count = buttonPositions.Count;
        int last = count - 1;
        for (var i =0; i<last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = buttonPositions[i];
            buttonPositions[i] = buttonPositions[r];
            buttonPositions[r] = tmp;
        }

        int counter = 0;
        foreach (int icon in icons)
        {
            GameObject button = Instantiate(buttonPreFab, buttonPositions[counter++], Quaternion.identity);
            button.GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameController").GetComponent<ResourceManager>().ready[icon];
            button.SetActive(true);
            button.GetComponent<ButtonController>().icon = icon;
            button.tag = "Button";
        }
    }

    public void checkIcons()
    {
        for (int i = 0; i < icons.Count; i++)
        {

            if (chosenItems.GetComponent<InteractionManager>().chosenIcons[i] != icons[i])
            {
                isWin = false;
                return;
            }
        }
        isWin = true;
        return;
    }

}

