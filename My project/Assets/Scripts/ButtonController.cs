using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject movingWalls;
    public bool hasInteracted = false;
    public int icon;
    void Start()
    {
        movingWalls.SetActive(false);
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
                case 0:
                    GameObject.Find("Player").GetComponent<PlayerController>().speed = 1000;
                    break;
                case 1:
                    GameObject.Find("GameController").GetComponent<WallControl>().isActive = true;
                    break;
                case 2:
                    GameObject staticEnemy = GameObject.Find("StaticEnemy");
                    staticEnemy.GetComponent<StaticEnemy>().isActive = true;
                    staticEnemy.transform.position = new Vector3(0, 0, 0);
                    break;
                case 3:
                    GameObject.Find("GameController").AddComponent<AddEnemy>();
                    break;
                case 4:
                    movingWalls.SetActive(true);
                    break;

                case 5:
                    GameObject.Find("GameController").GetComponent<ChangeIconsLocation>().ChangeLocation();
                    break;
                default:
                    break;
            }
            hasInteracted = true;
        }
    }
}
