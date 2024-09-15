using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_temp : MonoBehaviour
{
    private Transform Target;
    public float speed = 10f;
    [SerializeField] float rotateSpeed = 5f;

    Rigidbody2D rb;

    
    public void Seek(Transform _target)
    {
        Target = _target;

    }

    private void Start()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 dir = Target.position - transform.position;
        rb = GetComponent<Rigidbody2D>();
        //float distanceThisframe = speed * Time.deltaTime;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        //transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);

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
        float rotateAmount = Vector3.Cross(dir, transform.right).z;
        float distanceThisframe = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisframe)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisframe, Space.World);
        rb.angularVelocity = -rotateAmount * 500f;
        rb.velocity = -transform.up * 10f;

    }

    void HitTarget()
    {
        //Destroy(Target.gameObject);
        Destroy(gameObject);

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
}
