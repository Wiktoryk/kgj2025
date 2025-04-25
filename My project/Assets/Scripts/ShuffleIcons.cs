using Mono.Cecil;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleIcons : MonoBehaviour
{

    public List<int> icons;
    public List<IconData> generatedIcons = new List<IconData>();
    public int size;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            icons.Add(i);
            generatedIcons.Add(new IconData(i));
        }
        while( icons.Count > 0) 
        {
            int i = Random.Range( 0, icons.Count );
            GameObject go = new GameObject("IconID:"+ icons[i]);
            go.transform.parent = this.transform;
            go.AddComponent<SpriteRenderer>();
            Debug.Log(icons[i]);
            //Sprite sprite = Resources.Load<Sprite>("Assets/Sprites/"+ icons[i] + ".png");
            //go.GetComponent<SpriteRenderer>().sprite = sprite;
            icons.RemoveAt( i );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
