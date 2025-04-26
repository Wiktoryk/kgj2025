using UnityEngine;

public class AddEnemy : MonoBehaviour
{
    public GameObject enemyObjectPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Spawn()
    {
        GameObject enemyObject = Instantiate(enemyObjectPrefab, Vector3.zero, Quaternion.identity);
        enemyObject.AddComponent<EnemyMovement>();
        enemyObject.GetComponent<EnemyMovement>().playerPositon = GameObject.Find("Player").transform;
        enemyObject.GetComponent<EnemyMovement>().speed = 1;
    }
}
