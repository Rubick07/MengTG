using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Spawn : MonoBehaviour
{
    public GameObject Resource;
    public float timer;
    [SerializeField] float timerTemp;
    [SerializeField] GameObject ResourceReady;

    private void Start()
    {
        timerTemp = timer;
        timer = 0;
    }
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(1) && Is_Interact.InRange == true)
        {
            HP--;
        }
        */

        if(timer <= 0 && ResourceReady == null)
        {
            ResourceReady = (GameObject)Instantiate(Resource, transform);
            timer = timerTemp;
        }
        if(ResourceReady == null)
        {
            timer-= Time.deltaTime;
        }

    }

}
