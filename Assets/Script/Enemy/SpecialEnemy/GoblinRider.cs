using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinRider : MonoBehaviour
{
    public GameObject goblin;
    public Transform posisi;
    public GameObject parent;
    Enemy_path enemy_Path;
    Enemy_Spawner _Spawner;
    private void Start()
    {
        enemy_Path = GetComponent<Enemy_path>();
        _Spawner = GetComponentInParent<Enemy_Spawner>();
    }
    public void SpawnRider()
    {
        //Debug.Log("masuk");
        GameObject spawn = Instantiate(goblin, posisi);
        spawn.transform.SetParent(gameObject.transform.parent);
        Enemy_path enemy_ = spawn.GetComponent<Enemy_path>();
        enemy_.Wpoints = enemy_Path.Wpoints;
        enemy_.waypointIndex = enemy_Path.waypointIndex;

        Destroy(parent);
    }

}
