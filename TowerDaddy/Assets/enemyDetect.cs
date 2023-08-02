using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDetect : MonoBehaviour
{
    public Vector3 enemyTransform;

    public GameObject TurretBasic;

    public GameObject bullet;
    
 
    // Start is called before the first frame update
    void Start()
    {
        enemyTransform = Vector3.forward;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TurretBasic.GetComponent<ProjectileGun>().canShoot = true;
            enemyTransform = other.transform.position;
            bullet.GetComponent<bullet>().enemy.transform.position = enemyTransform;
       
        }
        else
        {
            enemyTransform = Vector3.forward;
        }
    }
}
