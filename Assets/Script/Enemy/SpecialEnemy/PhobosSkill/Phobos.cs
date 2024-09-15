using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phobos : MonoBehaviour
{
    public Transform AttackPos;
    public float AttackRange;
    public LayerMask TowerLayer;
    public float CDSkill;
    public float timer;
    public float FireDuration;
    public Animator animator;
    public GameObject FireEffect;
    public Vector3 offset;
    private Enemy enemy;
    public AudioSource audioSource;
    
    private void Start()
    {
        timer = CDSkill;
        
    }

    private void FixedUpdate()
    {
        enemy = GetComponent<Enemy>();
        
        if(enemy.HP <= 0)
        {
            Phobos phobos = GetComponent<Phobos>();
            phobos.enabled = false;
        }
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = CDSkill;
            animator.SetTrigger("Attack");
        }
    }

    public void DestroyTower()
    {
        audioSource.enabled = false;
        audioSource.enabled = true;
        Collider2D[] Towers = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, TowerLayer);
        
        foreach(Collider2D tower in Towers)
        {
            Tower_detect tower_Detect = tower.GetComponent<Tower_detect>();
            Tower_Ballista tower_Ballista = tower.GetComponent<Tower_Ballista>();
            Upgrade_Ruined upgrade_Ruined = tower.GetComponent<Upgrade_Ruined>();
            Upgrade_Ruined Watchtower = tower.GetComponentInChildren<Upgrade_Ruined>();
            Enchantree enchantree = tower.GetComponent<Enchantree>();
            Magmanator_detect magmanator_Detect = tower.GetComponent<Magmanator_detect>();
            Ruin_Fotress ruin_Fotress =tower.GetComponent<Ruin_Fotress>();
            Sunriser_Detect sunriser_Detect = tower.GetComponent<Sunriser_Detect>();
            
            if(tower_Detect != null)
            {
                tower_Detect.enabled = false;
                GameObject Fire = Instantiate(FireEffect, tower.transform.position + offset, transform.rotation);
                PhobosFire phobosFire = Fire.GetComponent<PhobosFire>();
                Fire.transform.SetParent(tower.transform);
                phobosFire.TimeLife = FireDuration;
            }
            else if(tower_Ballista != null)
            {
                tower_Ballista.enabled = false;
                GameObject Fire = Instantiate(FireEffect, tower.transform.position + offset, transform.rotation);
                PhobosFire phobosFire = Fire.GetComponent<PhobosFire>();
                Fire.transform.SetParent(tower.transform);
                phobosFire.TimeLife = FireDuration;
            }
            else if(upgrade_Ruined == null && Watchtower != null)
            {
                Watchtower.enabled = false; 
                GameObject Fire = Instantiate(FireEffect, tower.transform);
                PhobosFire phobosFire = Fire.GetComponent<PhobosFire>();
                Fire.transform.SetParent(tower.transform);
                phobosFire.TimeLife = FireDuration;
            }
            else if(upgrade_Ruined != null && Watchtower == null)
            {
                upgrade_Ruined.enabled = false;
                GameObject Fire = Instantiate(FireEffect, tower.transform.position + offset, transform.rotation);
                PhobosFire phobosFire = Fire.GetComponent<PhobosFire>();
                Fire.transform.SetParent(tower.transform);
                phobosFire.TimeLife = FireDuration;
            }
            else if(enchantree != null)
            {
                enchantree.enabled = false;
                GameObject Fire = Instantiate(FireEffect, tower.transform.position + offset, transform.rotation);
                PhobosFire phobosFire = Fire.GetComponent<PhobosFire>();
                Fire.transform.SetParent(tower.transform);
                phobosFire.TimeLife = FireDuration;
            }
            else if(magmanator_Detect != null)
            {
                magmanator_Detect.enabled = false;
                GameObject Fire = Instantiate(FireEffect, tower.transform);
                PhobosFire phobosFire = Fire.GetComponent<PhobosFire>();
                Fire.transform.SetParent(tower.transform);
                phobosFire.TimeLife = FireDuration;
            }
            else if(ruin_Fotress != null)
            {
                ruin_Fotress.enabled = false;
                GameObject Fire = Instantiate(FireEffect, tower.transform);
                PhobosFire phobosFire = Fire.GetComponent<PhobosFire>();
                Fire.transform.SetParent(tower.transform);
                phobosFire.TimeLife = FireDuration;
            }
            else if(sunriser_Detect != null)
            {
                sunriser_Detect.enabled = false;
                GameObject Fire = Instantiate(FireEffect, tower.transform.position + offset, transform.rotation);
                PhobosFire phobosFire = Fire.GetComponent<PhobosFire>();
                Fire.transform.SetParent(tower.transform);
                phobosFire.TimeLife = FireDuration;
            }



        }


    }

    void OnDrawGizmosSelected()
    {
        if (AttackPos == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);
    }
}
