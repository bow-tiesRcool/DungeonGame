using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using TMPro;
using UnityEngine;

public class ShootEnemyController : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float angle;

    public GameObject weapon;
    public WeaponController weaponController;

    public float speed = 3;
    private float savedTime;
    private int moveDirection;
    private float shootTime;
    private bool canShoot = true;
    private bool move;
    private float timeTillMove;

    void Awake()
    {
        move = false;
        timeTillMove = Random.Range(0, 3);
        rb = this.GetComponent<Rigidbody2D>();
        savedTime = Time.time;
        shootTime = Time.time;
        moveDirection = (int)Random.Range(0, 3);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine("Move");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        weapon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (move)
        {
            if (Time.time - savedTime <= 1)
            {
                switch (moveDirection)
                {
                    case 1:
                        rb.MovePosition((Vector2)transform.position + (Vector2.right * speed * Time.deltaTime));
                        break;
                    case 2:
                        rb.MovePosition((Vector2)transform.position + (Vector2.left * speed * Time.deltaTime));
                        break;
                    case 3:
                        rb.MovePosition((Vector2)transform.position + (Vector2.up * speed * Time.deltaTime));
                        break;
                    case 4:
                        rb.MovePosition((Vector2)transform.position + (Vector2.down * speed * Time.deltaTime));
                        break;
                    default:
                        break;
                }
            }
            else if (Time.time - savedTime >= 1 && Time.time - savedTime <= 5)
            {
            }
            else if (Time.time - savedTime > 5)
            {
                savedTime = Time.time;
                moveDirection = (int)Random.Range(1, 5);
            }

            if (canShoot)
            {
                canShoot = false;
                StartCoroutine("ShootCooldown");
            }
        }
    }

    IEnumerator ShootCooldown()
    {
        weaponController.singleShot();
        yield return new WaitForSeconds(3f);
        canShoot = true;
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(timeTillMove);
        move = true;
    }
}
