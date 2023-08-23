using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDetect : MonoBehaviour
{
    public Vector3 enemyTransform;

    public GameObject[] TurretBasic;

    public GameObject bullet;

    public GameObject[] bullets;
    public List <GameObject> enemies = new List<GameObject>();
 
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
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        
        
        if (other.CompareTag("Enemy"))
        {
            
            enemyTransform = other.transform.position;
            bullet.GetComponent<bullet>().enemy.transform.position = enemyTransform;
       
        }
        else
        {
            enemyTransform = Vector3.forward;
        
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Add(other.gameObject);
            StartCoroutine(ShootAllEnemiesInOrder());
            // TurretBasic.GetComponents<ProjectileGun>().canShoot = true;
            TurretBasic = GameObject.FindGameObjectsWithTag("Turret");
            foreach (GameObject turret in TurretBasic)
            {
                turret.GetComponent<ProjectileGun>().activateShooting = true;
            }
        }
        
    }
    IEnumerator ShootAllEnemiesInOrder()
    {
        foreach (GameObject enemy in enemies)
        {
            enemyTransform = enemy.transform.position;
            bullet.GetComponent<bullet>().enemy.transform.position = enemyTransform;
            yield return null;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StopShooting();
    }
    public void StopShooting()
    {
        foreach (GameObject turret in TurretBasic)
        {
            turret.GetComponent<ProjectileGun>().activateShooting = false;
        }
    }

}
