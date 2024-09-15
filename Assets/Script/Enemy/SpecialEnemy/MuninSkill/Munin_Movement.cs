using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munin_Movement : MonoBehaviour
{
    private Transform posisiAwal;
    Enemy_path enemy_Path;
    Waypoint Wpoint;
    Munin muninBuff;
    Munin_Control control;
    Munin_Movement _Movement;
    CapsuleCollider2D colliderMunin2D;
    public float speed;
    public int WaypointIndex;
    public Animator animator;
    public AudioSource audioSource;

    void Start()
    {
        enemy_Path = GetComponent<Enemy_path>();
        muninBuff = GetComponentInChildren<Munin>();
        control = GetComponent<Munin_Control>();
        _Movement = GetComponent<Munin_Movement>();
        colliderMunin2D = GetComponent<CapsuleCollider2D>();
        Wpoint = GameObject.FindGameObjectWithTag("Munin_Path").GetComponent<Waypoint>();

        colliderMunin2D.enabled = false;
        _Movement.enabled = true;
        WaypointIndex = 0;
    }

    public void GetPosAwal(GameObject PosAwal)
    {
        posisiAwal = PosAwal.transform;
    }


    private void FixedUpdate()
    {
        audioSource.enabled = true;
        Debug.LogWarning(WaypointIndex);
        Debug.Log(Wpoint.waypoints.Length);
        if(WaypointIndex < Wpoint.waypoints.Length)
        {
            animator.SetFloat("Arah", Wpoint.waypoints[WaypointIndex].position.x - transform.position.x);
            transform.position = Vector2.MoveTowards(transform.position, Wpoint.waypoints[WaypointIndex].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, Wpoint.waypoints[WaypointIndex].position) < 0.1f)
            {


                if (WaypointIndex < Wpoint.waypoints.Length)
                {
                    WaypointIndex++;
                }

            }
        }
        else
        {
            Debug.Log("Oke");
            transform.position = Vector2.MoveTowards(transform.position, posisiAwal.position, speed * Time.deltaTime);
            animator.SetFloat("Arah", posisiAwal.position.x - transform.position.x);
            if (Vector2.Distance(transform.position, posisiAwal.position) < 0.1f)
            {
                audioSource.enabled = false;
                animator.SetBool("IsAttacking", false);
                Destroy(control.PosAwal, 1f);
                control.enabled = true;
                colliderMunin2D.enabled = true;
                enemy_Path.enabled = true;
                control.timer = control.SkillCD;

                muninBuff.enabled = false;
                _Movement.enabled = false;

            }
        }




    }
}
