using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform playerPositon;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = Vector3.Normalize( playerPositon.position - this.transform.position);
        Quaternion targetDirection = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.down, -rb.linearVelocity));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetDirection, Time.deltaTime * 5);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("GameController").GetComponent<GameController>().isEnded = true;
        }
    }
}
