using UnityEngine;

public class WallMovement : MonoBehaviour
{

    public Vector3 targetPosition;
    private Vector3 startPosition;
    private Vector3 tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.localPosition;
        Debug.Log(startPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(targetPosition,transform.localPosition)<1)
        {
            tmp = targetPosition;
            targetPosition = startPosition;
            startPosition = tmp;

            Debug.Log(startPosition);

            Debug.Log(targetPosition);
        }
        else 
        {

            this.GetComponent<Rigidbody2D>().linearVelocity = Vector3.Normalize(targetPosition - this.transform.localPosition);
        }

    }
}
