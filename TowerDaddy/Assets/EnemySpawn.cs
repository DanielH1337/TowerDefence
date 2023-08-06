using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject spawnedEnemy;
    public float spawnTime;
    [SerializeField] private bool enemySpawning=true;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnEnemyDelay()
    {
        while (enemySpawning)
        {
            Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
        
    }
}
