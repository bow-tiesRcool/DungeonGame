using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController player;

    public Vector2 movementDirection;
    private float movementSpeed;

    public int life = 5;
    private bool canBeHit = true;

    public float playerSpeed;
    public Vector2 direction;
    private float angle;

    public GameObject weapon;
    public GameObject[] weapons;
    public WeaponController weaponController;
    private GameManager gameManager;

    Rigidbody2D _body;
    public Rigidbody2D body
    {
        get
        {
            if (_body == null)
            {
                _body = GetComponent<Rigidbody2D>();
            }
            return _body;
        }
    }

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        if (player == null)
        {
            player = this;
        }
    }

    //void Start()
    //{
    //    renderer = GetComponentInChildren<Renderer>();
    //    gun = GetComponent<SpriteRenderer>();
    //}

    void Update()
    {
        ProcessInputs();
        Move();
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        //body.velocity = new Vector2(x, y) * movementSpeed;
        //dir = Input.mousePosition - pos;
        //angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //if (body.velocity.sqrMagnitude > 0.1f)
        //{
        //    transform.right = body.velocity;
        //}
        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    bulletNum = 0;
        //    gun.sprite = GunName[0];
        //}

        ClampToScreen(GetComponent<Renderer>().bounds.extents.x);
        ClampToScreen(-GetComponent<Renderer>().bounds.extents.x);
        ClampToScreen(GetComponent<Renderer>().bounds.extents.y);
        ClampToScreen(-GetComponent<Renderer>().bounds.extents.y);
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
        direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        weapon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetButtonDown("Fire1"))
        {
            weaponController.isFiring = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            weaponController.isFiring = false;
        }
        if (Input.GetButtonDown("Switch"))
        {
            if (weapons[0].activeSelf == true)
            {
                weapons[1].SetActive(true);
                weapon = weapons[1];
                weaponController = weapon.GetComponent<WeaponController>();
                weapons[0].SetActive(false);
            }
            else
            {
                weapons[0].SetActive(true);
                weapon = weapons[0];
                weaponController = weapon.GetComponent<WeaponController>();
                weapons[1].SetActive(false);
            }
        }
    }

    void Move()
    {
        body.velocity = movementDirection * (movementSpeed * playerSpeed);
    }

    void ClampToScreen(float xOffset)
    {
        Vector3 v = Camera.main.WorldToViewportPoint(transform.position + Vector3.right * xOffset);
        v.x = Mathf.Clamp01(v.x);
        transform.position = Camera.main.ViewportToWorldPoint(v) - Vector3.right * xOffset;

        Vector3 u = Camera.main.WorldToViewportPoint(transform.position + Vector3.down * xOffset);
        u.y = Mathf.Clamp01(u.y);
        transform.position = Camera.main.ViewportToWorldPoint(u) - Vector3.down * xOffset;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "MeleeEnemy")
        //{
        //    Physics2D.IgnoreCollision(collision.collider, this.GetComponent<Collider2D>());
        //}
        if (collision.gameObject.tag == "ShootEnemy" || collision.gameObject.tag == "MeleeEnemy" || collision.gameObject.tag == "EnemyBullet")
        {
            if (canBeHit)
            {
                canBeHit = false;
                gameManager.LooseLife();
                StartCoroutine("HitCooldown");
            }
        }
    }

    IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(3f);
        canBeHit = true;
    }
}
