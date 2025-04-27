using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class StaticEnemy : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletPreFab;
    public GameObject emitterPreFab;
    private Vector3 direction;
    public float delay;
    public bool delayed = false;
    public bool isActive = false;
    
    void Start()
    {

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
                GameObject particleEmitter = Instantiate(emitterPreFab, bullet.transform.position, Quaternion.identity);
                particleEmitter.transform.parent = bullet.transform;
                delay = 1;
                delayed = true;
            }
            else if (bullet)
            {
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.linearVelocity = direction * 400 * Time.deltaTime;
                bullet.transform.rotation = Quaternion.RotateTowards(bullet.transform.rotation, Quaternion.Euler(0, 0, 90 + Vector2.SignedAngle(Vector2.down, rb.linearVelocity)), rb.linearVelocity.magnitude);
                bullet.transform.GetChild(0).rotation = Quaternion.RotateTowards(bullet.transform.rotation, Quaternion.Euler(0, 0, -Vector2.SignedAngle(Vector2.down, rb.linearVelocity)), rb.linearVelocity.magnitude);
            }
        }
    }
}
