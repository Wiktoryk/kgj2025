using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool hasInteracted = false;
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
            Debug.Log("Pressed");
            hasInteracted = true;
        }
    }
}
