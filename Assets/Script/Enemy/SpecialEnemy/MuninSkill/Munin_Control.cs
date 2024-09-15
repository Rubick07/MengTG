using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munin_Control : MonoBehaviour
{
    public float SkillCD;
    public float timer;
    public GameObject PosisiAwal;
    public GameObject PosAwal;
    public Animator animator;
    Enemy_path enemy_Path;
    Munin_Movement _Movement;
    Munin_Control _Control;
    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        enemy_Path = GetComponent<Enemy_path>();
        _Movement = GetComponent<Munin_Movement>();
        _Control = GetComponent<Munin_Control>();
        timer = SkillCD;
    }

    private void FixedUpdate()
    {

        if(enemy.HP <= 0)
        {
            _Control.enabled = false;
        }
     
        if(timer<= 0)
        {
            animator.SetBool("IsAttacking", true);
            enemy_Path.enabled = false;
            _Movement.enabled = true;
            _Movement.WaypointIndex = 0;
             PosAwal = Instantiate(PosisiAwal, transform);
            PosAwal.transform.parent = null;
            _Movement.GetPosAwal(PosAwal);
            _Control.enabled = false;
            
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }

}
