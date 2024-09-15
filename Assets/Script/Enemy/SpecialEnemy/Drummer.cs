using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drummer : MonoBehaviour
{
    public GameObject Particle;
    public string TypeBuff;
    public int buff;
    public float buff2;
    public float duration;

    Enemy enemy;
    Enemy_path enemy_Path;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        enemy_Path = GetComponent<Enemy_path>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            if(TypeBuff == "Speed")
            {
                Enemy_path enemy_Path = collision.gameObject.GetComponent<Enemy_path>();
                enemy_Path.TakeBuffSpeed(buff2, Mathf.Infinity);
                GameObject EffectPartile = Instantiate(Particle, collision.transform);
                EffectPartile.transform.SetParent(collision.transform);
                Destroy(EffectPartile, 1f);
            }

            else if(TypeBuff == "Defense")
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.TakeBuff(buff, Mathf.Infinity);
                GameObject EffectPartile = Instantiate(Particle, collision.transform);
                EffectPartile.transform.SetParent(collision.transform);
                Destroy(EffectPartile, 1f);
            }

        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            if (TypeBuff == "Speed")
            {
                Enemy_path enemy_Path = collision.gameObject.GetComponent<Enemy_path>();
                enemy_Path.TakeBuffSpeed(0, duration);

            }

            else if (TypeBuff == "Defense")
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.TakeBuff(0, duration);
            }

        }

    }


}
