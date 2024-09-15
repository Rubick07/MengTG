using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhobosFire : MonoBehaviour
{
    public float TimeLife;
    public Animator animator;
    private void FixedUpdate()
    {
        if(TimeLife<= 0)
        {
            animator.SetTrigger("Death");
        }
        TimeLife -= Time.deltaTime;
    }

    public void padam()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Tower_detect tower_Detect = GetComponentInParent<Tower_detect>();
        Tower_Ballista tower_Ballista = GetComponentInParent<Tower_Ballista>();
        Upgrade_Ruined upgrade_Ruined = GetComponentInParent<Upgrade_Ruined>();
        Enchantree enchantree = GetComponentInParent<Enchantree>();
        Magmanator_detect magmanator_Detect = GetComponentInParent<Magmanator_detect>();
        Ruin_Fotress ruin_Fotress = GetComponentInParent<Ruin_Fotress>();
        Sunriser_Detect sunriser_Detect = GetComponentInParent<Sunriser_Detect>();

        if (tower_Detect != null)
        {
            tower_Detect.enabled = true;
        }
        else if (tower_Ballista != null)
        {
            tower_Ballista.enabled = true;
        }
        else if (upgrade_Ruined != null)
        {
            upgrade_Ruined.enabled = true;
        }
        else if (enchantree != null)
        {
            enchantree.enabled = true;
        }
        else if (magmanator_Detect != null)
        {
            magmanator_Detect.enabled = true;
        }
        else if (ruin_Fotress != null)
        {
            ruin_Fotress.enabled = true;
        }
        else if (sunriser_Detect != null)
        {
            sunriser_Detect.enabled = true;
        }

    }
}
