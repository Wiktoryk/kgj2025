using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Linq;

public class ShuffleIcons : MonoBehaviour
{

    public List<int> icons;
    public List<IconData> generatedIcons = new List<IconData>();
    public GameObject display;
    public int size;
    public int optSize;
    
    void Start()
    {
        for (int i = 0; i < size + optSize; i++)
        {
            icons.Add(i);
        }
        while( icons.Count > 0) 
        {
            int i = Random.Range( 0, icons.Count );
            GameObject go = new GameObject("IconID:"+ icons[i]);
            generatedIcons.Add(new IconData(icons[i], icons.Count > optSize ? true : false));
            if (generatedIcons.Last().used)
            {
                go.transform.parent = display.transform;
                go.AddComponent<Image>();
                if (GameObject.Find("GameController").GetComponent<ResourceManager>().ready.Count > 0)
                {
                    go.GetComponent<Image>().sprite = GameObject.Find("GameController").GetComponent<ResourceManager>().ready[icons[i]];
                }
                else
                {
                    Sprite sprite = Resources.Load<Sprite>("runestones/" + (icons[i]) + "/" + (icons[i]) + "-ready");
                    go.GetComponent<Image>().sprite = sprite;
                }
            }
            icons.RemoveAt( i );
        }
    }
}
