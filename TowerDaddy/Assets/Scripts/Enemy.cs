using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("TowerBase").transform;
    }
    void Update()
    {
        enemy.SetDestination(player.position);
    }
}
