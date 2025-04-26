using UnityEngine;

public class AddEnemy : MonoBehaviour
{
    public GameObject enemyObject;
    public bool isActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyObject = new GameObject("Enemy");
        enemyObject.AddComponent<SpriteRenderer>();
        enemyObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("stone1");
        enemyObject.transform.position = Vector2.zero;
        enemyObject.AddComponent<EnemyMovement>();
        enemyObject.GetComponent<EnemyMovement>().playerPositon = GameObject.Find("Player").transform;
        enemyObject.GetComponent<EnemyMovement>().speed = 1;
        enemyObject.AddComponent<CircleCollider2D>();
        enemyObject.AddComponent<Rigidbody2D>();
        enemyObject.transform.localScale *= 0.1f;
        

        //enemyObject.SetActive(false);

    }
}
