using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private List<GameObject> toDestroy = new List<GameObject>();
    public GameObject czas;
    public float timeLeft;
    public float timeMax;
    private float hintTime = 5;
    
    void Start()
    {
        timeLeft = timeMax;
    }

    void Update()
    {
        if (hintTime > 0)
        {
            GameObject player = GameObject.Find("Player");
            player.transform.position = new Vector3(100, 100, 0);
            hintTime -= Time.deltaTime;
            if (hintTime <= 0)
            {
                Transform image = GameObject.Find("Canvas").transform.Find("Image");
                int currentCount = image.childCount;
                while (currentCount > 0)
                {
                    toDestroy.Add(image.GetChild(currentCount -1).gameObject);
                    currentCount--;
                }
                toDestroy.Add(GameObject.Find("Canvas").transform.Find("Background").gameObject);
                DestroyList();
                player.transform.position = new Vector3(0, 0, 0);
                GameObject.Find("InteractionManager").GetComponent<InteractionManager>().ButtonTest();
            }
        }
        else
        {
            if (timeLeft > 0 && !GameObject.Find("GameController").GetComponent<GameController>().isEnded)
            {
                timeLeft -= Time.deltaTime;
                //Debug.Log(timeLeft);
            }
            else
            {
                if (timeLeft < 0)
                {
                    timeLeft = 0;
                }
                GameObject.Find("GameController").GetComponent<GameController>().isEnded = true;
            }
        }
        czas.GetComponent<TextMeshProUGUI>().text = ((int)timeLeft).ToString() + " seconds";
    }

    void DestroyList()
    {
        for (int i = 0; i < toDestroy.Count; i++)
        {
            Destroy(toDestroy[i]);
        }
        toDestroy.Clear();
    }
}
