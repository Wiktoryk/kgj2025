using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.gameObject.name != "StaticEnemy(Clone)")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("GameController").GetComponent<GameController>().isEnded = true;
        }
    }

}
