using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Wave : MonoBehaviour
{

    public Text Wave_countdown;
    public Text WaveIndex;
    public Text WaveMax;
    public GameObject ButtonNextWave;

    int Index;
    Enemy_Spawner Countdown;
    Enemy_Spawner[] enemy_Spawners;
    SpawnerManager spawnerManager;

    // Start is called before the first frame update
    void Start()
    {
        Countdown = FindObjectOfType<Enemy_Spawner>().GetComponent<Enemy_Spawner>();
        enemy_Spawners = FindObjectsOfType<Enemy_Spawner>();
        spawnerManager = FindObjectOfType<SpawnerManager>().GetComponent<SpawnerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Index = Countdown.CurrentWaveIndex +1;

        if(Countdown.countdown != 0)
        {
            Wave_countdown.text = Countdown.countdown.ToString("0");
            WaveIndex.text = Index.ToString();
            WaveMax.text = Countdown.waves.Length.ToString();
        }

        if(Countdown.ReadyToCountdown == true)
        {
            ButtonNextWave.SetActive(true);
        }
        else
        {
            ButtonNextWave.SetActive(false);
        }
    }

    public void SkipTime()
    {
        SpawnerManager spawnerManager = FindObjectOfType<SpawnerManager>();
        spawnerManager.WaveSound.enabled = true;
        foreach(Enemy_Spawner enemy_ in enemy_Spawners)
        {
            Enemy_Spawner spawn = enemy_.GetComponent<Enemy_Spawner>();
            spawn.countdown = 0;

        }
    }

    
}
