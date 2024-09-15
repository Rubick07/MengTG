using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    int PlayerDamage = 1;
    public bool IsAttacking = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Enemy_path enemy_Path = collision.gameObject.GetComponent<Enemy_path>();
            Enemy_Aggro enemy_Aggro = collision.gameObject.GetComponent<Enemy_Aggro>();


            enemy.TakeDamage(PlayerDamage);
            if(enemy_Path.enabled == enabled)
            {
                enemy_Path.enabled = !enemy_Path.enabled;
            }
            enemy_Aggro.AggroTarget(gameObject);


        }
    }
}
