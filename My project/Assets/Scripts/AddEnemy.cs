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
        //enemyObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/enemy.png");
        enemyObject.GetComponent<SpriteRenderer>().color = Color.gray;
        enemyObject.transform.position = Vector2.zero;
        enemyObject.AddComponent<EnemyMovement>();
        enemyObject.GetComponent<EnemyMovement>().playerPositon = GameObject.Find("Player").transform;
        enemyObject.GetComponent<EnemyMovement>().speed = 1;
        enemyObject.AddComponent<Rigidbody2D>();
        enemyObject.AddComponent<Collider2D>();
        

        //enemyObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
