using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaUI : MonoBehaviour
{
    [Header("Tipe Turret")]
    public GameObject BallistaUP;
    public GameObject BallistaDown;
    public GameObject BallistaLeft;
    public GameObject BallistaRight;
    public GameObject TowerSebelum;
    public int CostCoin;
    public int CostWood;
    public int CostStone;
    [Header("Offset")]
    public Vector3 offset1;
    public Vector3 offset2;
    public Vector3 offset3;
    public Vector3 offset4;

    ResourceManager resource;

    private void Start()
    {
        resource = FindObjectOfType<ResourceManager>().GetComponent<ResourceManager>();
    }
    public void BuildUP()
    {
        if(resource.coin < CostCoin || resource.wood < CostWood || resource.stone < CostStone)
        {
            Debug.Log("sfds");
            return;
        }
        resource.MinusCoin(CostCoin);
        resource.MinusWood(CostWood);
        resource.MinusStone(CostStone);
        GameObject Building = (GameObject)Instantiate(BallistaUP, transform.position + offset1, transform.rotation);
        Building.transform.SetParent(null);
        Destroy(TowerSebelum);
    }
    public void BuildDown()
    {
        if (resource.coin < CostCoin || resource.wood < CostWood || resource.stone < CostStone)
        {
            return;
        }
        resource.MinusCoin(CostCoin);
        resource.MinusWood(CostWood);
        resource.MinusStone(CostStone);
        GameObject Building = (GameObject)Instantiate(BallistaDown, transform.position + offset2, transform.rotation);
        Building.transform.SetParent(null);
        Destroy(TowerSebelum);
    }
    public void BuildLeft()
    {
        if (resource.coin < CostCoin || resource.wood < CostWood || resource.stone < CostStone)
        {
            return;
        }
        resource.MinusCoin(CostCoin);
        resource.MinusWood(CostWood);
        resource.MinusStone(CostStone);
        GameObject Building = (GameObject)Instantiate(BallistaLeft, transform.position + offset3, transform.rotation);
        Building.transform.SetParent(null);
        Destroy(TowerSebelum);
    }
    public void BuildRight()
    {
        if (resource.coin < CostCoin || resource.wood < CostWood || resource.stone < CostStone)
        {
            return;
        }
        resource.MinusCoin(CostCoin);
        resource.MinusWood(CostWood);
        resource.MinusStone(CostStone);
        GameObject Building = (GameObject)Instantiate(BallistaRight, transform.position + offset4, transform.rotation);
        Building.transform.SetParent(null);
        Destroy(TowerSebelum);
    }








}
