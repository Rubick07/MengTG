using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerManager : MonoBehaviour
{
    Kristal kristal;
    public GameObject VictoryMenu;
    GameObject[] enemy_Spawners;
    public Animator animator;
    public AudioSource WaveSound;
    public bool ReadyNextWave;
    public bool Win;

    Enemy_Spawner _Spawner;
    // Start is called before the first frame update
    void Start()
    {
        enemy_Spawners = GameObject.FindGameObjectsWithTag("Spawner");
        kristal = FindObjectOfType<Kristal>();
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Win == true)
        {
            VictoryMenu.SetActive(true);
            Player_Input player_Input = FindObjectOfType<Player_Input>();
            player_Input.enabled = false;
            int SisaHP = kristal.HP;

            if(SisaHP >= 790 || StarsManager.Instance.stars[SceneManager.GetActiveScene().buildIndex-2] == 3)
            {;
                StarsManager.Instance.stars[SceneManager.GetActiveScene().buildIndex - 2] = 3;

            }
            else if(SisaHP >= 490 || StarsManager.Instance.stars[SceneManager.GetActiveScene().buildIndex - 2] == 2)
            {
                StarsManager.Instance.stars[SceneManager.GetActiveScene().buildIndex - 2] = 2;
            }
            else
            {
                StarsManager.Instance.stars[SceneManager.GetActiveScene().buildIndex - 2] = 1;
            }
            animator.SetInteger("Score", SisaHP);
        }
        _Spawner = enemy_Spawners[0].GetComponent<Enemy_Spawner>();
        if(_Spawner.countdown <= 0.5f)
        {
            Debug.Log("Oke");
            WaveSound.enabled = false;
            WaveSound.enabled = true;
        }




        foreach (GameObject spawner in enemy_Spawners)
        {
            Enemy_Spawner enemy_Spawner = spawner.GetComponent<Enemy_Spawner>();
            if(enemy_Spawner.CurrentWaveIndex >= enemy_Spawner.waves.Length)
            {
                Win = true;
                return;
            }
            if(enemy_Spawner.waves[enemy_Spawner.CurrentWaveIndex].enemiesLeft > 0)
            {
                ReadyNextWave = false;
                return;
            }
            ReadyNextWave = true;

        }

    }
}
