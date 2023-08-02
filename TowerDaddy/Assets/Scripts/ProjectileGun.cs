using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    public bool canShoot =false;

    void Update()
    {
        if (canShoot)
        {
            StartCoroutine(Shoot());
            canShoot = false;
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
