using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTower : MonoBehaviour
{
    public int MaxKnight = 3;
    public int KnightHidup = 0;
    private Transform Target;
    public Transform SpawnPoint;
    private float SpawnTime = 0f;
    private float SpawnRate = 3f;
    public GameObject KnightObject;
    public Transform RangePoint;
    public float Range;
    public Vector3 offset;  
    int MaxTarget = 3;
    public GameObject[] Enemies;
    private void Start()
    {
        Enemies = new GameObject[MaxTarget];

    }
    [SerializeField] private int EnemyLeft = 0;

    private void Update()
    {
        
        if(SpawnTime <= 0)
        {
            if(KnightHidup < EnemyLeft)
            {
                SpawnKnight();

            }
            SpawnTime = SpawnRate;
        }
        if(KnightHidup < MaxKnight)
        {
        SpawnTime -= Time.deltaTime;
        }
        

    }


    public void SpawnKnight()
    {
        GameObject Knights = (GameObject)Instantiate(KnightObject, SpawnPoint);
        Knights.transform.SetParent(transform);
        KnightHidup++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && collision.GetComponent<Phobos>() == null && collision.GetComponent<Munin_Control>() == null)
        {
            int cek = 0;
            while(cek < MaxTarget)
            {
                if(Enemies[cek] == null)
                {
                Enemies[cek] = collision.gameObject;
                EnemyLeft++;
                    return;
                }
                cek++;
            }
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            for(int i = 0; i<MaxTarget; i++)
            {
                if(Enemies[i] == collision.gameObject)
                {
                    Enemies[i] = null;
                    EnemyLeft--;
                }
            }
        }


    }

}
