using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich : MonoBehaviour
{
    public GameObject skeleton;
    public Transform Spawn1;
    public Transform Spawn2;

    [SerializeField] int MaxSkeleton;
    public int SkeletonHidup;
    [SerializeField] float Spawnrate;
    public Animator animator;
    float spawnTime;

    Enemy_path enemy_Path;
    Enemy_Spawner _Spawner;
    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        enemy_Path = GetComponent<Enemy_path>();
        _Spawner = GetComponentInParent<Enemy_Spawner>();
    }


    private void FixedUpdate()
    {
        if(enemy.HP <= 0)
        {
            Lich lich = GetComponent<Lich>();
            lich.enabled = false;
        }
        if (spawnTime <= 0)
        {
            if (SkeletonHidup < MaxSkeleton)
            {
                animator.SetTrigger("Summon");
            }
            spawnTime = 1f / Spawnrate;

        }
        if (SkeletonHidup < MaxSkeleton)
        {
            spawnTime -= Time.deltaTime;
        }

    }

    public void SpawnSkeleton()
    {
        for (int i = 0; i < 5; i++)
        {
            if(SkeletonHidup >= MaxSkeleton)
            {
                return;
            }
            int random = Random.Range(0, 2);
            GameObject Skeleton;
            if(random == 0)
            {
                Skeleton = (GameObject)Instantiate(skeleton, Spawn1);
                Skeleton.transform.SetParent(transform.parent);
                Enemy_path enemy_ = Skeleton.GetComponent<Enemy_path>();
                Enemy enemy = Skeleton.GetComponent<Enemy>();

                enemy_.Wpoints = enemy_Path.Wpoints;
                enemy_.waypointIndex = enemy_Path.waypointIndex;

                enemy.Inispawn = true;


            }
            else if(random == 1)
            {
                Skeleton = (GameObject)Instantiate(skeleton, Spawn2);
                Skeleton.transform.SetParent(transform.parent);
                Enemy_path enemy_ = Skeleton.GetComponent<Enemy_path>();
                Enemy enemy = Skeleton.GetComponent<Enemy>();

                enemy_.Wpoints = enemy_Path.Wpoints;
                enemy_.waypointIndex = enemy_Path.waypointIndex;

                enemy.Inispawn = true;
            }
            SkeletonHidup++;
            _Spawner.waves[_Spawner.CurrentWaveIndex].enemiesLeft++;
            

            
        }

    }
}
