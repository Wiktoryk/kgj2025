using UnityEngine;

public class ChangeIconsLocation : MonoBehaviour
{

    public void ChangeLocation()
    {
        GameObject[] runy =GameObject.FindGameObjectsWithTag("Button");
        Vector2 tmp = runy[0].transform.position;
        for (int i = 1; i < runy.Length; i++) 
        {
            runy[i - 1].transform.position = runy[i].transform.position;
        }
        runy[runy.Length-1].transform.position = tmp;

    }
}
