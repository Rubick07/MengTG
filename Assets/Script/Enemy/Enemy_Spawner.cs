using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [Header("Attributes")]
    public float countdown = 10f;
    public float time = 0;
    public GameObject kristal;
    [SerializeField]private GameObject Spawn_point;
    public SpawnerManager SpawnerM;
    [Header("Monster")]
    [Header("Attributes")]
    public Waypoint[] jalan;
    public int CurrentWaveIndex = 0;
    public Wave[] waves;

    
    public bool ReadyToCountdown;
    private GameObject spawner;

    private void Start()
    {
        ReadyToCountdown = true;
        

        for(int i = 0; i< waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }
    private void Update()
    {
        if(CurrentWaveIndex >= waves.Length)
        {
            Debug.Log("Selesai");
            StopAllCoroutines();
            return;
        }
        if(ReadyToCountdown == true)
        {
        countdown -= Time.deltaTime;
        }
        

        if(countdown <= 0)
        {
            countdown = 0;
            ReadyToCountdown = false;
            countdown = waves[CurrentWaveIndex].TimeToNextWave;
            StartCoroutine(Spawn_Wave());
        }
        if(waves[CurrentWaveIndex].enemiesLeft == 0 && SpawnerM.ReadyNextWave == true)
        {
            ReadyToCountdown = true;
            CurrentWaveIndex++;
        }

    }

    private IEnumerator Spawn_Wave()
    {
        
        if(CurrentWaveIndex < waves.Length)
        {
        for(int i = 0; i< waves[CurrentWaveIndex].enemies.Length; i++)
        {
            Enemy enemy = Instantiate(waves[CurrentWaveIndex].enemies[i], Spawn_point.transform);
                Enemy_path Jalan = enemy.GetComponent<Enemy_path>();
                int random = Random.Range(0, jalan.Length);
                Debug.Log(random);
                Jalan.Wpoints = jalan[random];
                
            enemy.transform.SetParent(Spawn_point.transform);

            yield return new WaitForSeconds(waves[CurrentWaveIndex].TimeToNextEnemies);
        }
        }

    }

}
    [System.Serializable]

    public class Wave
    {
    public Enemy[] enemies;
    public float TimeToNextEnemies;
    public float TimeToNextWave;
    public int enemiesLeft;
        
    }


