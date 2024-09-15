using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    [Header("Input Public")]
    public int damage = 5;
    public float kecepatan = 5f;
    public float Temp_Kecepatan;
    public Rigidbody2D Player;
    public int Hp;
    public float Attack_rate = 2f;
    public AudioSource Footstep;
    public AudioSource PickUP;
    public AudioSource AttackSound;
    [Header("Aggro Enemy")]
    public Transform AttackPoint;
    public float AttackRange;
    public LayerMask EnemyLayer;
    public LayerMask ResourceLayer;


    float nextAttackTime = 0f;

    public Animator animator;
    public static Player_Input player;
    Vector2 movement;
    

    private void Start()
    {
        Temp_Kecepatan = kecepatan;
    }

    private void Awake()
    {
        player = this;
    }


    void Update()
    {  
        // Input Movement
       movement.x = Input.GetAxis("Horizontal");
       movement.y = Input.GetAxis("Vertical");
        //Set Animation jalan
       animator.SetFloat("Horizontal", movement.x);
       animator.SetFloat("Vertical", movement.y);
       animator.SetFloat("Speed", movement.sqrMagnitude);

        if(movement.magnitude  > 0)
        {
            animator.SetFloat("Idle_Hor", movement.x);
            animator.SetFloat("Idle_Ver", movement.y);
        }

        if(Time.time >= nextAttackTime)
        {
             if (Input.GetMouseButtonDown(1))
             {
               Attack();
               nextAttackTime = Time.time + 1f / Attack_rate;
             }
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow))
        {
            Footstep.enabled = true;
        }
        else
        {
            Footstep.enabled = false;
        }

    }
    

    void FixedUpdate()
    {
        //Movement
        Player.MovePosition(Player.position + movement * kecepatan * Time.fixedDeltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Update Resource
        if (collision.gameObject.tag == "Wood")
        {
            PickUP.enabled = false;
            PickUP.enabled = true;
            Destroy(collision.gameObject);
            ResourceManager.Instance.AddWood(1);
        }
        else if (collision.gameObject.tag == "Stone")
        {
            PickUP.enabled = false;
            PickUP.enabled = true;
            Destroy(collision.gameObject);
            ResourceManager.Instance.AddStone(1);
        }
        else if(collision.gameObject.tag == "Mana")
        {
            PickUP.enabled = false;
            PickUP.enabled = true;
            Destroy(collision.gameObject);
            ResourceManager.Instance.AddMana(1);
        }
    }

    void Attack()
    {
        //kecepatan = 0;
        AttackSound.enabled = false;
        AttackSound.enabled = true;
        animator.SetTrigger("Attack");
        Collider2D[] TargetEnemy = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayer);
        Collider2D[] Resources = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, ResourceLayer);
        foreach (Collider2D musuh in TargetEnemy)
        {
            //Debug.Log("Kena");

                Enemy enemy = musuh.gameObject.GetComponent<Enemy>();
                Enemy_path enemy_Path = musuh.gameObject.GetComponent<Enemy_path>();
                Enemy_Aggro enemy_Aggro = musuh.gameObject.GetComponent<Enemy_Aggro>();

                enemy.TakeDamage(damage);
                enemy.countdownAggro = enemy.countdownAggroTemp;
                if(enemy_Path.enabled == enabled && musuh.GetComponent<Phobos>() == null && musuh.GetComponent<Munin>() == null)
            {
                enemy_Path.enabled = false;
            }
                if(enemy_Aggro != null)
            {
                enemy_Aggro.AggroTarget(gameObject);
            }
            
            
        }
        foreach(Collider2D resource in Resources)

        {
            ResourceStat resource_ = resource.GetComponent<ResourceStat>();
            resource_.Sound.enabled = false;
            resource_.Sound.enabled = true;
            resource_.HP--;
        }



    }

    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }




}
