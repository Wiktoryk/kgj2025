using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
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
        Debug.Log(ready.Count);
    }
}
