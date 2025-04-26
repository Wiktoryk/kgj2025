using NUnit.Framework;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHover : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        transform.GetChild(1).gameObject.SetActive(false);
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
        }else
        {

            Application.Quit();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        transform.GetChild(1).gameObject.SetActive(true);

        collision.transform.GetChild(0).gameObject.SetActive(false);
    }
}
