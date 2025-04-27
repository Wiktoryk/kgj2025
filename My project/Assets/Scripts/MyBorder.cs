using UnityEngine;

public class MyBorder : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().linearVelocity *= -1;
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().linearVelocity *= -1;
    }

    void Update()
    {
        if (this.gameObject.transform.localPosition.x > 900)
        {
            this.gameObject.transform.localPosition = new Vector2(900, this.gameObject.transform.localPosition.y);
        }
        else if (this.gameObject.transform.localPosition.x < -900)
        {
            this.gameObject.transform.localPosition = new Vector2(-900, this.gameObject.transform.localPosition.y);
        }

        if (this.gameObject.transform.localPosition.y > 500)
        {
            this.gameObject.transform.localPosition = new Vector2( this.gameObject.transform.localPosition.x,500);
        }
        else if (this.gameObject.transform.localPosition.y < -500)
        {
            this.gameObject.transform.localPosition = new Vector2(this.gameObject.transform.localPosition.x, -500);
        }
    }
}
