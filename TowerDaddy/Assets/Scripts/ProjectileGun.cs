using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    public bool canShoot;

    public bool activateShooting=false;

    private void Start()
    {
        canShoot = true;
        
    }
    void Update()
    {
        if (activateShooting)
        {
            if (canShoot)
            {
                StartCoroutine(Shoot());
                canShoot = false;
            }
        }
        
          
    }
    IEnumerator Shoot()
    {
        Instantiate(bulletPrefab);
        bulletPrefab.transform.position = firepoint.transform.position;
        yield return new WaitForSeconds(1f);
        canShoot = true;
        

    }

}
