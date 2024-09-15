using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursed_Grave : MonoBehaviour
{
    public int Debuff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Enemy_path>() != null)
        {
            //Enemy_path enemy_Path = collision.GetComponent<Enemy_path>();
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.def = enemy.def - (enemy.def * Debuff) / 100;
            enemy.MagicDef = enemy.MagicDef - (enemy.MagicDef * Debuff) / 100;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy_path>() != null)
        {
            Debug.Log("Keluar");
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.MagicDef = enemy.MagicDef - (enemy.MagicDef * Debuff) / 100;
        }

    }
}
