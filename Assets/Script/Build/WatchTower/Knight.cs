using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField]private GameObject Target;
    [SerializeField]private int NoKnight;
    [Header("Stats")]
    public float speed = 1f;
    public int HP = 50;
    public int Attack = 10;
    public float AttackRate;
    [Header("Aggro Enemy")]
    public float AttackRange;    
    public Transform AttackPoint;
    public LayerMask EnemyLayer;
    public Animator animator;
    public AudioSource AttackSound;

    float AttackCountdown = 0f;
    private WatchTower Tower;
    private GameObject EnemyTarget;
    public Vector3 offset;
    Enemy_path EnemyPath;
    Enemy_Aggro EnemyLock;


    
    private void Start()
    {
        Tower = GetComponentInParent<WatchTower>();

        NoKnight = Tower.KnightHidup;
        if(Tower.Enemies[NoKnight-1] == null)
        {
        for(int i = 0; i< Tower.MaxKnight; i++)
        {
            if(Tower.Enemies[i] != null)
            {
            Target = Tower.Enemies[i];
            EnemyTarget = Tower.Enemies[i];
                break;
            }
            
        }
        }
        else
        {
            Target = Tower.Enemies[NoKnight - 1];
            EnemyTarget = Tower.Enemies[NoKnight - 1];
        }


        EnemyPath = EnemyTarget.GetComponent<Enemy_path>();
        if(EnemyPath.enabled == enabled && EnemyTarget.GetComponent<Phobos>() == null && EnemyTarget.GetComponent<Munin_Control>() == null)
        {
        EnemyPath.enabled = false;
        }
        

        EnemyLock = EnemyTarget.GetComponent<Enemy_Aggro>();
        if(EnemyLock != null)
        {
        EnemyLock.AggroTarget(gameObject);
        }
        

        
    }

    private void Update()
    {
        if(HP <= 0)
        {
            Tower.KnightHidup--;
            Destroy(gameObject);
        }
        if(Target == null)
        {
            Tower.KnightHidup--;
            Destroy(gameObject);
        }
        else
        {
            if(Vector2.Distance(transform.position, Target.transform.position) <= AttackRange)
            {
                if(Time.time >= AttackCountdown)
                {
                    Debug.Log("Masuk");
                    GoAttack();
                    AttackCountdown = Time.time + 1f / AttackRate;
                }

            }
            else
            {
               // Debug.Log(Vector2.Distance(transform.position, Target.transform.position));
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position , speed * Time.deltaTime);
            animator.SetFloat("Arah", Target.transform.position.x - transform.position.x);
            }
        

        }

    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }

    public void GoAttack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] TargetEnemy = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayer);

        foreach(Collider2D musuh in TargetEnemy)
        {

            if(musuh.gameObject == Target)
            {
                Enemy enemy = musuh.gameObject.GetComponent<Enemy>();

                //Debug.Log(enemy);
                enemy.TakeDamage(Attack);
                enemy.countdownAggro = enemy.countdownAggroTemp;
            }

        }
    }

    public void AttackSoundTrigger()
    {
        AttackSound.enabled = false;
        AttackSound.enabled = true;
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
