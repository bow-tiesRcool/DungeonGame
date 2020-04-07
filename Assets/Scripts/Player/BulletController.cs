using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float lifeSpan = 3;
    void Update()
    {

    }

    public void Fire()
    {
        gameObject.SetActive(true);
        //AudioManager.PlayEffect("Laser_Shoot7", 1, 1);
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.velocity = transform.up * speed;
        StartCoroutine("LifecycleCoroutine");
    }

    IEnumerator LifecycleCoroutine()
    {
        yield return new WaitForSeconds(lifeSpan);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.gameObject.tag == "Bullet")
        //{
        //    Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //}
        if (col.gameObject.tag == "Wall")
        {
            gameObject.SetActive(false);
        }
    }
}
