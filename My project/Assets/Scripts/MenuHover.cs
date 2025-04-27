using NUnit.Framework;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHover : MonoBehaviour
{
    public GameObject player;
    public Sprite prox;
    private Sprite tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        tmp = this.gameObject.GetComponent<Image>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.GetComponent<Image>().sprite = prox;
        collision.transform.GetChild(0).gameObject.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (this.gameObject.name == "Start")
            {
                SceneManager.LoadScene("Level1");
            }
            else if(this.gameObject.name.Substring(0,5)=="Level")
            {

                SceneManager.LoadScene(this.gameObject.name);
            }
            else if (this.gameObject.name == "Exit")
            {
                Application.Quit();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        tmp = this.gameObject.GetComponent<Image>().sprite = tmp;

        collision.transform.GetChild(0).gameObject.SetActive(false);
    }
}
