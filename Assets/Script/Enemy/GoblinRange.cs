using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinRange : MonoBehaviour 
{
    [SerializeField] float AttackRange;
    public float CountdownInRange;
    public Transform SpawnPeluru;
    public GameObject peluru;
    [SerializeField] Transform AttackPoint;
    [SerializeField] LayerMask GuardianMask;

    Enemy_Aggro _Aggro;
    Enemy_path enemy_Path;
    // Start is called before the first frame update
    void Start()
    {
        _Aggro = GetComponent<Enemy_Aggro>();
        enemy_Path = GetComponent<Enemy_path>();
        AttackRange = _Aggro.AttackRange;
        AttackPoint = _Aggro.AttackPoint;
        GuardianMask = _Aggro.TargetMask;
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("UpdateTarget", 0f, CountdownInRange);
    }

    void UpdateTarget()
    {
        Collider2D[] Guardian = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, GuardianMask);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach(Collider2D Guard in Guardian)
        {
            float distanceToGuard = Vector2.Distance(transform.position, Guard.transform.position);
            if(distanceToGuard < shortestDistance)
            {
                shortestDistance = distanceToGuard;
                nearestEnemy = Guard.gameObject;
            }
        }

        if(nearestEnemy != null && shortestDistance < AttackRange)
        {
            enemy_Path.enabled = false;
            _Aggro.AggroTarget(nearestEnemy);
        }


    }
}
