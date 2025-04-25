using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool hasInteracted = false;
    public int icon;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Interaction()
    {
        if(!hasInteracted)
        {
            switch (icon)
            {
                case 1:
                    Debug.Log("1");
                    break;
                case 2:
                    GameObject.Find("GameController").AddComponent<AddEnemy>();
                    break;
                default:
                    break;
            }
            hasInteracted = true;
        }
    }
}
