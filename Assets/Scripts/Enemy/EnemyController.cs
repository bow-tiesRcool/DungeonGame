using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 direction;

    public float speed = 2;
    public float chaseDistance = 3;
    private float savedTime;
    private int moveDirection;
    private bool move;
    private float timeTillMove;

    void Awake()
    {
        move = false;
        timeTillMove = Random.Range(0, 3);
        rb = this.GetComponent<Rigidbody2D>();
        savedTime = Time.time;
        moveDirection = (int)Random.Range(1, 4);
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
        direction.Normalize();
        movement = direction;
        if (Vector2.Distance(transform.position, player.position) < chaseDistance)
        {
            rb.MovePosition((Vector2)transform.position+(movement * speed * Time.deltaTime));
        }
        else if(move)
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
                        rb.MovePosition((Vector2)transform.position + (Vector2.down * speed * Time.deltaTime));
                        break;
                }
            }
            else if (Time.time - savedTime >= 1 && Time.time - savedTime <= 5)
            {

            }
            else if (Time.time - savedTime > 5)
            {
                savedTime = Time.time;
                moveDirection = (int)Random.Range(1, 4);
            }
        }
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(timeTillMove);
        move = true;
    }
}
