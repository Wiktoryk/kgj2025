using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float moveHorizontal;
    private float moveVertical;
    public bool inverted = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        rb.linearVelocity = !inverted ?
            new Vector2 (moveHorizontal * Time.deltaTime * speed, moveVertical * Time.deltaTime * speed) :
            new Vector2(-moveHorizontal * Time.deltaTime * speed, moveVertical * Time.deltaTime * speed);
        if(moveHorizontal!=0 || moveVertical != 0)
        {
            Quaternion targetDirection = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.down, rb.linearVelocity));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetDirection, Time.deltaTime * 5);
            GetComponent<Animator>().enabled = true;
        }
        if (rb.linearVelocity.magnitude == 0)
        {
            GetComponent<Animator>().enabled = false;
        }
       
    }
}
