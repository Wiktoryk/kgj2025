using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject Particle;
    public GameObject Shooter;
    public bool hasInteracted = false;
    public IconData iconData;

    public void Interaction()
    {
        if(!hasInteracted)
        {
            switch (iconData.icon)
            {   
                case 0:
                    GameObject.Find("Player").GetComponent<PlayerController>().speed = 1000;
                    break;
                case 1:
                    GameObject.Find("GameController").GetComponent<WallControl>().isActive = true;
                    break;
                case 2:
                    GameObject staticEnemy = Instantiate(Shooter, Vector3.zero, Quaternion.identity);
                    staticEnemy.SetActive(true);
                    staticEnemy.GetComponent<StaticEnemy>().isActive = true;
                    //staticEnemy.transform.position = Vector3.zero;
                    Instantiate(Particle, Vector3.zero, Quaternion.identity);
                    break;
                case 3:
                    GameObject.Find("GameController").GetComponent<AddEnemy>().Spawn();
                    Instantiate(Particle, Vector3.zero, Quaternion.identity);
                    break;
                case 4:
                    for (int i = 0;i< GameObject.Find("MovingWalls").transform.childCount; i++)
                    {
                        GameObject.Find("MovingWalls").transform.GetChild(i).GetComponent<WallMovement>().speed = 1;
                    }
                    
                    break;

                case 5:
                    GameObject.Find("GameController").GetComponent<ChangeIconsLocation>().ChangeLocation();
                    break;
                case 6:
                    GameObject.Find("Player").GetComponent<PlayerController>().inverted = true;
                    break;
                default:
                    break;
            }
            hasInteracted = true;
        }
    }
}
