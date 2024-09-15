using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    //public bool hover = false;
    TowerUpgrade tower;

    private void Start()
    {
        tower = GetComponentInParent<TowerUpgrade>();
        //Debug.Log(tower);
    }

    private void OnMouseEnter()
    {
        tower.hover1 = true;
    }

    private void OnMouseExit()
    {
        tower.hover1 = false;
    }

}
