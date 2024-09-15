using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    CircleCollider2D Interactable;
    public float Range = 1f;
    public bool InRange = false;


    private void Start()
    {
        Interactable = GetComponentInParent<CircleCollider2D>();
        Interactable.radius = Range;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            InRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
        InRange = false;
        //Nodes.build.Close_Build();
        }

    }
}
