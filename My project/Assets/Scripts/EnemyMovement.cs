using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerPositon;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().linearVelocity = Vector3.Normalize( playerPositon.position - this.transform.position);
        //if(Colider2D.IsTouching(transform.GetComponent<CircleCollider2D>(),GameObject.Find("Player").GetComponent<CircleCollider2D>()))
        //{
            
        //}
    }

    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        Debug.Log("Dzia³a kolizja");
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("GameController").GetComponent<GameController>().isEnded = true;
        }
    }
}
