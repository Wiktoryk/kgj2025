using UnityEngine;
using System;

public class StaticEnemy : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletPreFab;
    private Vector3 direction;
    public float delay;
    public bool delayed = false;
    public bool isActive = false;
    
    void Start()
    {
        transform.position = new Vector3(-100,-100,0);
    }

    void Update()
    {
        if (isActive)
        {
            if (delay > 0 && !delayed)
            {
                delay -= Time.deltaTime;
                return;
            }
            else
            {
                delay -= Time.deltaTime;
                if (delay < 0)
                {
                    delayed = false;
                }
            }
            if (bullet == null && !delayed)
            {
                bullet = Instantiate(bulletPreFab, transform.position, Quaternion.identity);
                direction = GameObject.Find("Player").transform.position - bullet.transform.position;
                direction = direction.normalized;
                delay = 1;
                delayed = true;
            }
            else if (bullet)
            {
                bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * 400 * Time.deltaTime;
            }
        }
    }
}
