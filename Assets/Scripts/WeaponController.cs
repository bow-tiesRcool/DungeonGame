using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public bool isFiring;

    public string attackType;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                //BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                //newBullet.Fire();
                GameObject projectile = null;
                projectile = Spawner.Spawn(attackType);
                projectile.transform.position = firePoint.position;
                projectile.transform.rotation = firePoint.rotation;
                //projectile.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                projectile.GetComponent<BulletController>().Fire();
            }
        } else
        {
            shotCounter = 0;
        }
    }
}
