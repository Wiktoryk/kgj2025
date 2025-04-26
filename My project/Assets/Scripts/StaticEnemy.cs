using UnityEngine;
using System;

public class StaticEnemy : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletPreFab;
    private Vector3 direction;
    public bool isActive = false;
    void Start()
    {
        transform.position = new Vector3(-100,-100,0);
    }

    void Update()
    {
        if (isActive)
        {
            if (bullet == null)
            {
                bullet = Instantiate(bulletPreFab, transform.position, Quaternion.identity);
                direction = GameObject.Find("Player").transform.position - bullet.transform.position;
            }
            else
            {
                bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(Math.Sign(direction.x), Math.Sign(direction.y), Math.Sign(direction.z)) * 100 * Time.deltaTime;
            }
        }
    }
}
