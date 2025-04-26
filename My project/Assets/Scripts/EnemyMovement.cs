using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerPositon;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().linearVelocity = Vector3.Normalize( playerPositon.position - this.transform.position);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Dzia�a kolizja");
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("GameController").GetComponent<GameController>().isEnded = true;
        }
    }
}
