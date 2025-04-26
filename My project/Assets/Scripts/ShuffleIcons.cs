using Mono.Cecil;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ShuffleIcons : MonoBehaviour
{

    public List<int> icons;
    public List<IconData> generatedIcons = new List<IconData>();
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
            generatedIcons.Add(new IconData(icons[i]));
            go.transform.parent = display.transform;
            go.AddComponent<Image>();
            Debug.Log(icons[i]);
            Sprite sprite = Resources.Load<Sprite>("tree runes/"+ (icons[i]+1));
            go.GetComponent<Image>().sprite = sprite;
            icons.RemoveAt( i );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
