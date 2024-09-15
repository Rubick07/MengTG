using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform Target;
    public float speed = 10f;
    public float rotate_speed = 200f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Seek(Transform _target)
    {
        Target = _target;
        
    }


    // Update is called once per frame
    void Update()
    {
        if(Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = (Vector2)Target.position - rb.position;
//        dir.Normalize();

        float rotateAmount = Vector3.Cross(dir, transform.right).z;

        float distanceThisframe = speed * Time.deltaTime;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        //transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotate_speed);
        transform.Translate(dir.normalized * distanceThisframe, Space.World);

        rb.angularVelocity = -rotateAmount * rotate_speed;

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
    void HitTarget()
    {
        //Destroy(Target.gameObject);
        Destroy(gameObject);
        
    }
}
