using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Sprite> ready;
    public List<Sprite> used;
    public List<Sprite> prox;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            ready.Add(Resources.Load<Sprite>("runestones/" + i + "/" + i + "-ready"));
            used.Add(Resources.Load<Sprite>("runestones/" + i + "/" + i + "-used"));
            prox.Add(Resources.Load<Sprite>("runestones/" + i + "/" + i + "-prox"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
