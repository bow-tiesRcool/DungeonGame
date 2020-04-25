using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public static BossController boss;
    public string bossName;
    public float bossHealth = 100;
    public float bossSpeed;
    public Vector2 direction;
    public GameObject weapon;
    public GameObject[] weapons;
    public WeaponController weaponController;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(bossHealth <= 75)
        {
            anim.SetTrigger("Form2");
        }
        else if(bossHealth <= 0)
        {
            anim.SetTrigger("Death");
        }
    }

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
        if (boss == null)
        {
            boss = this;
        }
    }
}

