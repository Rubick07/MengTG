using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Aggro : MonoBehaviour
{
    [Header("Aggro Enemy")]
    GameObject Target;
    public float attackRate;
    public string EnemyType;
    public Transform AttackPoint;
    public LayerMask TargetMask;
    public float AttackRange;
    public Animator animator;
    public AudioSource AggroSound;

    float AttackCountdown = 0f;
    float speed;
    int attack; 
    Enemy_path speedReal;
    Enemy enemy;   
    Enemy_Aggro enemyAggro;

    public void AggroTarget(GameObject _Target)
    {
        Target = _Target;
    }
    private void Start()
    {
        speedReal = GetComponent<Enemy_path>();
        enemy = GetComponent<Enemy>();
         enemyAggro = GetComponent<Enemy_Aggro>();
        
        //speed = speedReal.speed;
    }

    private void FixedUpdate()
    {
        attack = enemy.Damage;
        speed = speedReal.speed;
        //gerak ke Target
        if (Target == null)
        {
            enemyAggro.enabled = false;
        }
        else
        {
            //cek distance kristal
            if(Target.GetComponent<Kristal>() != null)
            {
                Kristal kristal = Target.GetComponent<Kristal>();
                GameObject vertical;
                GameObject horizontal;

                if(Vector2.Distance(transform.position, kristal.Posisiatas.gameObject.transform.position) < 
                    Vector2.Distance(transform.position, kristal.Posisibawah.transform.position))
                {
                    vertical = kristal.Posisiatas.gameObject;
                }
                else
                {
                    vertical = kristal.Posisibawah.gameObject;
                }

                if (Vector2.Distance(transform.position, kristal.Posisikiri.gameObject.transform.position) <
                Vector2.Distance(transform.position, kristal.Posisibawah.gameObject.transform.position))
                {
                    horizontal = kristal.Posisikiri.gameObject;
                }
                else
                {
                    horizontal = kristal.Posisikanan.gameObject;
                }

                if(Vector2.Distance(transform.position, vertical.gameObject.transform.position) < 
                    Vector2.Distance(transform.position, horizontal.gameObject.transform.position))
                {
                    Target = vertical;
                }
                else
                {
                    Target = horizontal;
                }

            }


                if(Vector2.Distance(AttackPoint.position, Target.transform.position) <= AttackRange)
                {
                    if(Time.time >= AttackCountdown)
                    {
                    
                       if(EnemyType == "melee")
                        {
                        AttackGuardian();
                        }

                       else if(EnemyType == "range")
                        {
                        
                        animator.SetTrigger("Attack");
                        enemy.countdownAggro = enemy.countdownAggroTemp;
                        }

                    AttackCountdown = Time.time + 1f / attackRate;
                     }
            
                 }
                else
                {
                //Debug.Log(Vector2.Distance(AttackPoint.position, Target.transform.position));
                AggroSound.enabled = false;
                transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
                animator.SetFloat("Arah", Target.transform.position.x - transform.position.x);
                }
            


        }


    }


    public void AttackGuardian()
    {
        Debug.Log("serang");
        AggroSound.enabled = false;
        AggroSound.enabled = true;
        animator.SetTrigger("Attack");
        enemy.countdownAggro = enemy.countdownAggroTemp;
        Collider2D[] TargetCollider = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, TargetMask);


        foreach(Collider2D Guardian in TargetCollider)
        {

            if(Guardian.gameObject == Target && Target.GetComponentInParent<Kristal>() == null)
            {
                if (Guardian.gameObject.GetComponent<Player>() != null)
                {

                    Player player = Guardian.gameObject.GetComponent<Player>();
                    //Debug.Log(player);
                    player.TakeDamage(attack);
                }
                else if (Guardian.gameObject.GetComponent<Knight>() != null)
                {
                    Knight knight = Guardian.gameObject.GetComponent<Knight>();
                    knight.TakeDamage(attack);
                }
            }
            else if (Guardian.gameObject.GetComponentInParent<Kristal>() != null)
            {
                Kristal kristal = Guardian.gameObject.GetComponentInParent<Kristal>();
                kristal.TakeDamage(attack);
            }
        }
    }

    public void AttackGuardianRange()
    {
        AggroSound.enabled = false;
        AggroSound.enabled = true;
        GoblinRange goblinRange = GetComponent<GoblinRange>();
        GameObject peluru = (GameObject)Instantiate(goblinRange.peluru, goblinRange.SpawnPeluru);
        Enemy_Projectile enemy_Projectile = peluru.GetComponent<Enemy_Projectile>();
        enemy_Projectile.TargetPosition(Target.transform);
        enemy_Projectile.transform.SetParent(null);
        
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
