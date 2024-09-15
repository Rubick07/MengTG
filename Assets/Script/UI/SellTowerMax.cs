using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellTowerMax : MonoBehaviour
{
    public GameObject TowerSebelum;
    public GameObject Node;
    public Transform SpawnNode;
    public Vector3 offset;
    public int Sell;
    public int SellWood;
    public int SellStone;
    public int SellMana;
    ResourceManager resource;
    private void Start()
    {
        resource = FindObjectOfType<ResourceManager>().GetComponent<ResourceManager>();
    }
    public void sell()
    {
        resource.AddCoin(Sell);
        resource.AddWood(SellWood);
        resource.AddStone(SellStone);
        resource.AddMana(SellMana);
        GameObject Building = (GameObject)Instantiate(Node, SpawnNode.position + offset, transform.rotation);
        Building.transform.SetParent(null);
        Destroy(TowerSebelum);
    }
}
