using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Ruined : MonoBehaviour
{
    public Transform range_point;
    public GameObject duri_path;
    public float range;
    public int damage;
    public float DamageRate;
    public float DamageCountdown;

    public LayerMask duriLayer;
    public LayerMask duriDestroy;
    public LayerMask EnemyLayer;
    public Vector3 offset;

    private void Start()
    {
        Collider2D[] duri_active = Physics2D.OverlapCircleAll(range_point.position, range, duriLayer);
        Collider2D[] duriUpgrade_active = Physics2D.OverlapCircleAll(range_point.position, range, duriDestroy);
        /*
        foreach(Collider2D jalanan in duriUpgrade_active)
        {
            Destroy(jalanan);
        }
        */
        foreach (Collider2D jalanan in duri_active)
        {
            
            GameObject duri = Instantiate(duri_path, jalanan.transform.position + offset, transform.rotation);
            duri.transform.SetParent(transform);
        }

    }

    private void Update()
    {
        Collider2D[] Enemies = Physics2D.OverlapCircleAll(range_point.position, range, EnemyLayer);

        if (DamageCountdown <= 0f)
        {
            foreach (Collider2D enemy in Enemies)
            {
                Enemy musuh = enemy.GetComponent<Enemy>();
                Debug.Log(musuh);
                if (musuh.IsDuri == true)
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
