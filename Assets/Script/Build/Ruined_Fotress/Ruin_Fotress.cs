using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruin_Fotress : MonoBehaviour
{
    public Transform range_point;
    public GameObject duri_path;
    public float range;
    public int damage;
    public float DamageRate;
    public float DamageCountdown;
    public LayerMask duriLayer;
    public LayerMask EnemyLayer;
    public float offset;
    Collider2D[] duri_active;
    private void Start()
    {
         duri_active = Physics2D.OverlapCircleAll(range_point.position, range, duriLayer);

        foreach(Collider2D jalanan in duri_active)
        {
            GameObject duri = Instantiate(duri_path, jalanan.transform);
            duri.transform.SetParent(transform);
        }
    }

    private void Update()
    {
        Collider2D[] Enemies = Physics2D.OverlapCircleAll(range_point.position, range, EnemyLayer);

        if(DamageCountdown <= 0f)
        {
            foreach(Collider2D enemy in Enemies)
            {
                Enemy musuh = enemy.GetComponent<Enemy>();
                if(musuh.IsDuri == true && enemy.GetComponent<Munin_Control>() == null)
                {
                    musuh.TakeDamage(damage);
                }

            }

            DamageCountdown = 1f / DamageRate;

        }
        else
        {
            DamageCountdown -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (range_point == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(range_point.position, range);
    }


}
