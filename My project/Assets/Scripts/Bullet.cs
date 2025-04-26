using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(gameObject);
        
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("GameController").GetComponent<GameController>().isEnded = true;
        }
    }

}
