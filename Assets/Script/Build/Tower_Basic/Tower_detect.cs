using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_detect : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform Target;

    [Header("Attributes")]
    public float range = 15f;
    public float firerate = 1f;
    private float firecountdown = 0f;

    [Header("Unity Setup Fields")]
    public Animator animator;
    public AudioSource audioSource;
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public Transform firepoint;



    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            Target = nearestEnemy.transform;
        }
        else
        {
            Target = null;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(Target == null)
        {
            return;
        }

        if(firecountdown <= 0f)
        {
            animator.SetTrigger("Tembak");
            firecountdown = 1f / firerate;

        }

        firecountdown -= Time.deltaTime;


    }

    void Shoot()
    {
        //animator.SetTrigger("Tembak");
        audioSource.enabled = false;
        audioSource.enabled = true;
        GameObject bulletGo = (GameObject) Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Bullet_temp bullet = bulletGo.GetComponent<Bullet_temp>();

        if(bullet != null)
        {
            bullet.Seek(Target);
        }

    }
    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range);
    }
  */
}
