using UnityEngine;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public float timeMax;
    private float hintTime = 5;
    private List<GameObject> toDestroy = new List<GameObject>();
    void Start()
    {
        timeLeft = timeMax;
    }

    void Update()
    {
        if (hintTime > 0)
        {
            hintTime -= Time.deltaTime;
            if (hintTime <= 0)
            {
                Transform image = GameObject.Find("Canvas").transform.GetChild(0);
                int currentCount = image.childCount;
                while (currentCount > 0)
                {
                    toDestroy.Add(image.GetChild(currentCount -1).gameObject);
                    currentCount--;
                }
                DestroyList();
            }
        }
        else
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                Debug.Log(timeLeft);
            }
            else
            {
                timeLeft = 0;
            }
        }
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
