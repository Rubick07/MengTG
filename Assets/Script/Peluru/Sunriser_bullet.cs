using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunriser_bullet : MonoBehaviour
{

    private Transform Target;
    public float speed = 10f;

    public void Seek(Transform _target)
    {
        Target = _target;

    }
    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = Target.position - transform.position;

        float distanceThisframe = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisframe)
        {
            //HitTarget();
            StartCoroutine(HitTarget());
            //Destroy(gameObject);
            return;
        }
        else
        {
           transform.Translate(dir.normalized * distanceThisframe, Space.World);
        }
        



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null && collision.gameObject == Target.gameObject)
        {
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

        }
    }

    IEnumerator HitTarget()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

}
