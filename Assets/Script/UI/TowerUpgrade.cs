using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgrade : MonoBehaviour
{
    [Header("Tipe Turret")]
    public GameObject UpgradeUI;
    public GameObject BallistaGroup;
    public GameObject DeksUI;
    public GameObject Tower1;
    public GameObject Tower2;
    public GameObject Node;
    [Header("Offset")]
    public Vector3 offset;
    public Vector3 offset2;
    public Vector3 offset3;
    public string Text1;
    public string Text2;
    public Text text;
    public Text Cointext;
    public Text Woodtext;
    public Text Stonetext;
    public Text Manatext;
    public bool hover1 = false;
    public bool hover2 = false;
    private Transform posisi;
    [SerializeField]private bool aktif = false;
    public GameObject TowerSebelum;
    [Header("Build1")]
    public int CostCoin1;
    public int CostWood1;
    public int CostStone1;
    public int CostMana1;
    [Header("Build2")]
    public int CostCoin2;
    public int CostWood2;
    public int CostStone2;
    public int CostMana2;
    [Header("Sell")]
    public int Coin;
    public int Wood;
    public int Stone;
    public int Mana;
    ResourceManager Resource;


    private void Start()
    {
        Resource = FindObjectOfType<ResourceManager>().GetComponent<ResourceManager>();
        posisi = GetComponentInParent<Transform>();

    }

    private void Update()
    {
        if(hover1 == true || hover2 == true)
        {
            DeksUI.SetActive(true);
            if(hover1 == true)
            {
                text.text = Text1;
                Cointext.text = CostCoin1.ToString();
                Woodtext.text = CostWood1.ToString();
                Stonetext.text = CostStone1.ToString();
                Manatext.text = CostMana1.ToString();
            }

            if(hover2 == true)
            {
                text.text = Text2;
                Cointext.text = CostCoin2.ToString();
                Woodtext.text = CostWood2.ToString();
                Stonetext.text = CostStone2.ToString();
                Manatext.text = CostMana2.ToString();
            }
        }

        if(hover1 == false && hover2 == false)
        {
            DeksUI.SetActive(false);
        }

    }

    public void Build1()
    {
        if(Resource.coin < CostCoin1)
        {
            Debug.Log("Duit Gk Cukup");
            return;
        }
        Resource.MinusCoin(CostCoin1);
        Resource.MinusWood(CostWood1);
        Resource.MinusStone(CostStone1);
        Resource.MinusMana(CostMana1);
        GameObject Building = (GameObject)Instantiate(Tower1, posisi.position + offset, transform.rotation);
        Building.transform.SetParent(null);
        Destroy(TowerSebelum);
    }

    public void Build2()
    {
        if (Resource.coin < CostCoin2)
        {
            Debug.Log("Duit Gk Cukup");
            return;
        }
        Resource.MinusCoin(CostCoin2);
        Resource.MinusWood(CostWood2);
        Resource.MinusStone(CostStone2);
        Resource.MinusMana(CostMana2);
        GameObject Building = (GameObject)Instantiate(Tower2, posisi.position + offset2, transform.rotation);
        Building.transform.SetParent(null);
        Destroy(TowerSebelum);
    }

    public void sell()
    {
        Resource.AddCoin(Coin);
        Resource.AddWood(Wood);
        Resource.AddStone(Stone);
        Resource.AddMana(Mana);
        GameObject Building = (GameObject)Instantiate(Node, posisi.position + offset3, transform.rotation);
        Building.transform.SetParent(null);
        Destroy(TowerSebelum);
    }

    public void BallistaUI()
    {
        aktif = !aktif;
        BallistaGroup.SetActive(aktif);
    }

}
