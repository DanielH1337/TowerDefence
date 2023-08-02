using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public GameObject playerGO;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("TowerBase").transform;
        playerGO = GameObject.FindGameObjectWithTag("TowerBase");
    }
    void Update()
    {
        enemy.SetDestination(player.position);

    }
    private void OnCollisionEnter(Collision collision)
    {
        
        playerGO.GetComponent<Player>().takeDamage();
        playerGO.GetComponentInChildren<enemyDetect>().StopShooting();
        Destroy(gameObject);
    }
}
