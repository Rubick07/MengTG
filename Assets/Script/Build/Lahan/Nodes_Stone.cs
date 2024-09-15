using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes_Stone : MonoBehaviour
{
    ResourceManager bahan;
    public int CostMaterial;
    public bool Build = false;
    public Color hoverColor;
    private Color StartColor;
    private Renderer rend;


    private void Start()
    {
        bahan = FindObjectOfType<ResourceManager>().GetComponent<ResourceManager>();
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;

    }
    private void OnMouseDown()
    {
        if (bahan.stone < CostMaterial)
        {
            Debug.Log("Gak ada Bahan");
            return;
        }
        Build = true;
        ResourceManager.Instance.MinusStone(CostMaterial);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
}
