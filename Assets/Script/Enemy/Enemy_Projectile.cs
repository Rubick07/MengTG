using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour
{
    private Transform Target;
    public float timer;
    public int damage;
    public float speed;
    public float baseSpeed;
    public float rotate_Speed;
    Rigidbody2D rb;

    public void TargetPosition(Transform _target)
    {
        Target = _target;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        Vector3 dir = Target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));


        rb.velocity = new Vector2(dir.x, dir.y).normalized * speed;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotate_Speed);

    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.GetComponent<Player>() != null)
       {
                Player player = collision.gameObject.GetComponent<Player>();
                player.TakeDamage(damage);
            Destroy(gameObject);
       }
        else if(collision.gameObject.GetComponent<Knight>() != null)
        {
            Knight knight = collision.gameObject.GetComponent<Knight>();
            knight.TakeDamage(damage);
            Destroy(gameObject);
        }
        
       else if(collision.gameObject.GetComponent<Kristal>() != null)
        {
            Kristal kristal = collision.gameObject.GetComponent<Kristal>();
            kristal.TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
