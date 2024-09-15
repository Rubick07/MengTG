using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballista : MonoBehaviour
{
    [Header("Attributes")]
    public int hit = 3;
    public float speed = 5f;
    public Transform posisiAwal;
    Rigidbody2D rb;
    Tower_Ballista range;


    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        range = GetComponentInParent<Tower_Ballista>();

       rb.velocity = new Vector2(range.x * speed, speed * range.y);

        //posisiAwal = GetComponentInParent<Transform>();

    }

    private void Update()
    {
        //Debug.Log(Vector2.Distance(transform.position, posisiAwal.position));
        if(Vector2.Distance(transform.position, posisiAwal.position) > range.range)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            hit--;
            Bullet_Stat bullet_Stat = GetComponent<Bullet_Stat>();
            Enemy enemy = collision.GetComponent<Enemy>();
            if (bullet_Stat.DamageType == "Magic")
            {

                enemy.TakeDamageMagic(bullet_Stat.BulletDamage);
            }
            else if (bullet_Stat.DamageType == "Physic")
            {
                enemy.TakeDamage(bullet_Stat.BulletDamage);
            }

            if(hit == 0)
            {
                Destroy(gameObject);
                return;
            }
        }
    }



}

