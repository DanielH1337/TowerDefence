using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public GameObject playerGO;
    public GameObject enemydetect;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("TowerBase").transform;
        playerGO = GameObject.FindGameObjectWithTag("TowerBase");
        enemydetect = GameObject.FindGameObjectWithTag("BulletRange");
    }
    void Update()
    {
        if (enemy.isActiveAndEnabled)
        {
            enemy.SetDestination(player.position);
        }
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        //Take damage if enemy object collides with player
        if (collision.gameObject.CompareTag("TowerBase"))
        {
            playerGO.GetComponent<Player>().takeDamage();
        }
        playerGO.GetComponentInChildren<enemyDetect>().StopShooting();
        enemydetect.GetComponent<enemyDetect>().enemies.Remove(gameObject);
        Destroy(gameObject);
    }
}
