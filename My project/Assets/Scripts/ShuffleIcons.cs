using Mono.Cecil;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ShuffleIcons : MonoBehaviour
{

    public List<int> icons;
    public List<int> generatedIcons = new List<int>();
    public int size;
    public GameObject display;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            icons.Add(i);
        }
        while( icons.Count > 0) 
        {
            int i = Random.Range( 0, icons.Count );
            GameObject go = new GameObject("IconID:"+ icons[i]);
            generatedIcons.Add(icons[i]);
            go.transform.parent = display.transform;
            go.AddComponent<Image>();
            Debug.Log(icons[i]);
            if (GameObject.Find("GameController").GetComponent<ResourceManager>().ready.Count > 0)
            {
                go.GetComponent<Image>().sprite = GameObject.Find("GameController").GetComponent<ResourceManager>().ready[icons[i]];
            }
            else
            {
                Sprite sprite = Resources.Load<Sprite>("runestones/" + (icons[i]) + "/" + (icons[i]) + "-ready");
                go.GetComponent<Image>().sprite = sprite;
            }
            icons.RemoveAt( i );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
