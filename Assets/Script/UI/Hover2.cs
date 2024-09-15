using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover2 : MonoBehaviour
{
    TowerUpgrade tower;

    private void Start()
    {
        tower = GetComponentInParent<TowerUpgrade>();
        //Debug.Log(tower);
    }

    private void OnMouseEnter()
    {
        tower.hover2 = true;
    }

    private void OnMouseExit()
    {
        tower.hover2 = false;
    }
}
