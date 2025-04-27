using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public struct IconData
{
    public int icon;
    public bool used;

    public IconData(int icon, bool used)
    {
        this.icon = icon;
        this.used = used;
    }
}

public class GameController : MonoBehaviour
{
    public List<IconData> icons = new List<IconData>();
    public List<Vector3> buttonPositions;
    public GameObject buttonPreFab;
    public GameObject chosenItems;
    public GameObject EndText;
    public Sprite LoseSprite;
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
            if (!isWin)
            {
                EndText.transform.GetComponent<Image>().sprite = LoseSprite;
            }
            EndText.SetActive(true);
            EndText.transform.parent.GetChild(1).gameObject.SetActive(true);
            foreach (Transform child in EndText.transform.parent.GetChild(1))
            {
                child.gameObject.SetActive(false);
            }
            StartCoroutine(SwitchAfterDelay());

        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start");
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

        foreach (IconData iconData in icons)
        {
            GameObject button = Instantiate(buttonPreFab, buttonPositions[counter++], Quaternion.identity);
            button.GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameController").GetComponent<ResourceManager>().ready[iconData.icon];
            button.SetActive(true);
            button.GetComponent<ButtonController>().iconData = iconData; ;
            button.tag = "Button";
        }
        icons = GetComponent<ShuffleIcons>().generatedIcons.Where(icon => icon.used == true).ToList();
        
    }

    public void checkIcons()
    {
        for (int i = 0; i < icons.Count; i++)
        {

            if (chosenItems.GetComponent<InteractionManager>().chosenIcons[i] != icons[i].icon)
            {
                isWin = false;
                return;
            }
        }
        isWin = true;
        return;
    }

    IEnumerator<WaitForSeconds> SwitchAfterDelay()
    {
        yield return new WaitForSeconds(3.0f);
        if (isWin)
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
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

