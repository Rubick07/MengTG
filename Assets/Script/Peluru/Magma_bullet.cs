using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma_bullet : MonoBehaviour
{
    private Transform Target;
    public int damageLedakan;
    Transform spawn_point;
    Vector3 TargetPos;
    public Animator animator;
    public LayerMask enemylayer;
    public float range;

    private Rigidbody2D rb;

    public void Seek(Transform _target)
    {
        Target = _target;
        spawn_point = transform;
    }

    private void Start()
    {

        if(Target != null)
        {
        TargetPos = Target.position;
        }
        
        
        spawn_point = GetComponentInParent<Transform>();
        spawn_point = transform.parent;
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }
        //Debug.Log("posisi" + transform.position);
        //Debug.Log("Target" + TargetPos);
        
        TargetPos.z = 0;
        float angle;
        float v0;
        float time;
        float height = TargetPos.y + TargetPos.magnitude / 2f;

        HitungPakeTinggi(TargetPos, height, out v0, out angle, out time);
        //StopAllCoroutines();
        //StartCoroutine(Coroutine_Movement(v0, angle, time));
        StartCoroutine(Curve(transform.position, TargetPos));

        
    }

    void HitTarget()
    {
        //Destroy(Target.gameObject);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, enemylayer);

        foreach(Collider2D enemy in enemies)
        {
            Enemy musuh = enemy.GetComponent<Enemy>();
            musuh.TakeDamageMagic(damageLedakan);
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

    public void Destroy()
    {
        Destroy(gameObject);
    }


    private float HitungQuadraticEquation(float a , float b , float c, float sign)
    {
        return (-b + sign * Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);
    }
    private void HitungPakeTinggi(Vector3 TargetPos, float h, out float v0, out float angle, out float time)
    {
        float xt = TargetPos.x;
        float yt = TargetPos.y;
        float g = -Physics.gravity.y;

        float b = Mathf.Sqrt(2 * g * h);
        float a = (-0.5f * g);
        float c = -yt;

        float tplus = HitungQuadraticEquation(a, b, c, 1);
        float tmin = HitungQuadraticEquation(a, b, c, -1);

        time = tplus > tmin ? tplus : tmin;
        angle = Mathf.Atan(b * time / xt);

        v0 = b / Mathf.Sign(angle);

    }
    //untuk ckptw saja
    /*
    private void HitungPakeSudut(Vector3 TargetPos, float angle, out float v0, out float time )
    {
        float xt = TargetPos.x;
        float yt = TargetPos.y;
        float g = -Physics.gravity.y;

        float v1 = Mathf.Pow(xt, 2) * g;
        float v2 = 2 * xt * Mathf.Sin(angle) * Mathf.Cos(angle);
        float v3 = 2 * yt * Mathf.Pow(Mathf.Cos(angle), 2);
        v0 = Mathf.Sqrt(v1 / (v2 - v3));

        time = xt / (v0 * Mathf.Cos(angle));
    }

    IEnumerator Coroutine_Movement(float v0, float angle, float time)
    {
        
        float t = 0;
        while(t < time)
        {
            float x = v0 * t * Mathf.Cos(angle);
            float y = v0 * t * Mathf.Sin(angle) - (1f / 2f) * -Physics.gravity.y * Mathf.Pow(t, 2);
            transform.position = spawn_point.position +  new Vector3(x, y, 0);

            t += Time.deltaTime;
            
            if(t >= time || v0 == 0)
            {
                Destroy(gameObject);
            }
            yield return null;

            
        }
    }

    */
    // yang dipakai
        public AnimationCurve curve;

        [SerializeField] private float duration = 1.0f;

        [SerializeField] private float maxHeightY = 3.0f;

        public IEnumerator Curve(Vector3 start, Vector3 finish)
        {
            var timePast = 0f;


            //temp vars
            while (timePast < duration)
            {
                timePast += Time.deltaTime;

                var linearTime = timePast / duration; //0 to 1 time
                var heightTime = curve.Evaluate(linearTime); //value from curve

                var height = Mathf.Lerp(0f, maxHeightY, heightTime); //clamped between the max height and 0

                transform.position = Vector3.Lerp(start, finish, linearTime) + new Vector3(0f, height, 0f); //adding values on y axis

                yield return null;
            }

            if(transform.position == finish)
        {
            animator.SetTrigger("Destroy");
        }
        

    }

    void OnDrawGizmosSelected()
    {
        if (transform.position == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
