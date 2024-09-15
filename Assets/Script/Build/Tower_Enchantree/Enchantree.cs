using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enchantree : MonoBehaviour
{
    private Transform Target;
    [Header("Attributes")]
    public float range = 15f;
    public float firerate = 1f;
    public int minShoot;
    public int maxShoot;
    private float firecountdown = 0f;

    [Header("Unity Setup Fields")]
    public Animator animator;
    public AudioSource Recharge;
    public AudioSource Tembak;
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public Transform firepoint;
    public Vector3 Random_Spawn;



    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            Target = nearestEnemy.transform;
        }
        else
        {
            Target = null;
        }


    }
    void Update()
    {
        if (Target == null)
        {
            return;
        }

        if (firecountdown <= 0f)
        {
            animator.SetTrigger("Tembak");            
            firecountdown = 1f / firerate;

        }
        firecountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        Tembak.enabled = false;
        Tembak.enabled = true;
        int tembak = Random.Range(minShoot, maxShoot + 1);
        //animator.SetTrigger("Attacking");
        for(int i = 0; i < tembak; i++)
        {
        Random_Spawn.x = Random.Range(-1f, 1f);
        Random_Spawn.y = Random.Range(-1f, 1f);
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firepoint.position + Random_Spawn, firepoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(Target);
        }

        }


        


    }

    public void RechargeSound()
    {
        Recharge.enabled = false;
        Recharge.enabled = true;
    }
    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range);
    }
    */
}
