using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    public Text Cointxt;
    public Text Woodtxt;
    public Text Stonetxt;
    public Text Manatxt;
    public AudioClip audioClip;

    public int wood = 0;
    public int stone = 0;
    public int mana = 0;
    public int coin = 0;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Cointxt.text = coin.ToString();
        Woodtxt.text = wood.ToString();
        Stonetxt.text = stone.ToString();
        Manatxt.text = mana.ToString();
        
    }
    public void AddCoin(int Coin)
    {
        coin += Coin;
        Cointxt.text = coin.ToString();
    }
    public void MinusCoin(int Coin)
    {
        coin -= Coin;
        Cointxt.text = coin.ToString();
    }
    public void AddWood(int Wood)
    {
        wood += Wood;
        Woodtxt.text = wood.ToString();

    }
    public void AddStone(int Stone)
    {
        stone += Stone;
        Stonetxt.text =stone.ToString();
    }
    public void AddMana(int Mana)
    {
        mana += Mana;
        Manatxt.text =mana.ToString();
    }
    public void MinusWood(int cost)
    {
        wood -= cost;
        Woodtxt.text =wood.ToString();
    }
    public void MinusStone(int cost)
    {
        stone -= cost;
        Stonetxt.text = stone.ToString();
    }
    public void MinusMana(int cost)
    {
        mana -= cost;
        Manatxt.text = mana.ToString();
    }
}
