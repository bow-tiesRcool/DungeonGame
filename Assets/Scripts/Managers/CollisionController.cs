using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "MeleeEnemy")
        //{
        //    Physics2D.IgnoreCollision(collision.collider, this.GetComponent<Collider2D>());
        //}
        if (collision.gameObject.tag == "ShootEnemy")
        {
            Physics2D.IgnoreCollision(collision.collider, this.GetComponent<Collider2D>());
        }
    }
}
