using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDrummer : MonoBehaviour
{
    public int heal;
    public GameObject HealParticle;
    public LayerMask EnemyLayer;
    public float Healrange;
    public Transform HealPosition;
    public float Healtime;
    [SerializeField]float HealCountdown;
    public Animator animator;
    public AudioSource HealSound;
    Enemy enemy2;
    private void Start()
    {
        HealCountdown = Healtime;
    }
    private void FixedUpdate()
    {
        enemy2 = GetComponent<Enemy>();
        if(enemy2.HP <= 0)
        {
            enemy2.enabled = false;
        }
        
        if (HealCountdown<= 0)
        {
            HealSound.enabled = false;
            animator.SetTrigger("Heal");
            HealCountdown = Healtime;
        }
        
        HealCountdown -= Time.deltaTime;


    }


    public void Heal()
    {
        HealSound.enabled = true;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(HealPosition.position, Healrange, EnemyLayer);

        foreach (Collider2D enemy in enemies)
        {
            Enemy enemy1 = enemy.gameObject.GetComponent<Enemy>();
            enemy1.Healing(heal);
            GameObject Particle = Instantiate(HealParticle, enemy.transform);
            Destroy(Particle, 1f);
        }
        

    }

    void OnDrawGizmosSelected()
    {
        if (HealPosition == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(HealPosition.position, Healrange);
    }

    
}
