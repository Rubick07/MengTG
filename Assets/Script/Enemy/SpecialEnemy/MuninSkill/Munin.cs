using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munin : MonoBehaviour
{
    private int buffRand;
    public int buff;
    public float buff2;
    public float duration;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() != null)
        {
            buffRand = Random.Range(0, 2);

            if(buffRand == 0)
            {
                Enemy_path enemy_Path = collision.gameObject.GetComponent<Enemy_path>();
                enemy_Path.TakeBuffSpeed(buff2, duration);

            }
            else if(buffRand == 1)
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.TakeBuff(buff, duration);
            }

        }

    }

}
