using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_path : MonoBehaviour
{
    public float speed;
    public float BaseSpeed;
    public float BuffSpeed;
    public float duration;
    public Animator animator;
    public Waypoint Wpoints;
    public int waypointIndex;
    //public GameObject kristal;
    private Enemy_Spawner enemy_Spawner;
    private Vector2 move;
    Enemy_Aggro aggro;
    Enemy_path enemy_Path;
    void Start()
    {
        enemy_Spawner = GetComponentInParent<Enemy_Spawner>();
        aggro = GetComponent<Enemy_Aggro>();
        enemy_Path = GetComponent<Enemy_path>();
        BaseSpeed = speed;
    }

    private void FixedUpdate()
    {
        if(duration <= 0)
        {
            BuffSpeed = 0;

        }
        else
        {
            duration -= Time.deltaTime;
        }
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, (speed + BuffSpeed) * Time.deltaTime);
        animator.SetFloat("Arah", Wpoints.waypoints[waypointIndex].position.x - transform.position.x);


        if (Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {


            if (waypointIndex < Wpoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                enemy_Path.enabled = false;
                aggro.AggroTarget(enemy_Spawner.kristal);
                if(gameObject.GetComponent<Phobos>() != null || gameObject.GetComponent<Munin_Control>() != null)
                {
                    Kristal kristal = enemy_Spawner.kristal.GetComponent<Kristal>();
                    kristal.HP = 0;
                }
                //sebelum diubah
                //Destroy(gameObject);
                //enemy_Spawner.waves[enemy_Spawner.CurrentWaveIndex].enemiesLeft--;
            }
        }
    }

    public void TakeBuffSpeed(float Buffspeed, float Buffduration)
    {
        BuffSpeed += Buffspeed;
        duration = Buffduration;
    }

}
