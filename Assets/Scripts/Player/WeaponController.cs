using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public bool isFiring;

    public string attackType;
    public string projectileType;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;
    public Vector2 direction;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                if(attackType == "SingleShot")
                {
                    singleShot();
                }
                if(attackType == "SpreadShot")
                {
                    spreadShot();
                }
                //BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                //newBullet.Fire(); 
                //projectile.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            }
        } else
        {
            shotCounter = 0;
        }
    }

    void singleShot()
    {
        GameObject projectile = null;
        projectileShot(projectile, 0).GetComponent<BulletController>().Fire();
    }

    void spreadShot()
    {
        GameObject projectile = null;
        projectileShot(projectile, -10).GetComponent<BulletController>().Fire();
        
        GameObject projectile1 = null;
        projectileShot(projectile1, 0).GetComponent<BulletController>().Fire();
        
        GameObject projectile2 = null;
        projectileShot(projectile2, 10).GetComponent<BulletController>().Fire();
    }

    private GameObject projectileShot(GameObject projectile, float fireAngle)
    {
        projectile = Spawner.Spawn(projectileType);
        projectile.transform.position = firePoint.position;
        projectile.transform.rotation = Quaternion.AngleAxis(angle + fireAngle, Vector3.forward);
        return projectile;
    }
}
