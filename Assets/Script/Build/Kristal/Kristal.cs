using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kristal : MonoBehaviour
{
    public AudioSource BrokenSound;
    public int HP;
    public int MaxHP;
    [Header("Posisi")]
    public GameObject Posisiatas;
    public GameObject Posisibawah;
    public GameObject Posisikiri;
    public GameObject Posisikanan;
    [Header("LoseMenu")]
    public GameObject LoseUi;

    public Animator animator;
    
    public HealthBar health;

    private Follow_Camera follow_Camera;

    private void Start()
    {
        MaxHP = HP;
        health.SetMaxHealth(HP);
        follow_Camera = FindObjectOfType<Follow_Camera>().GetComponent<Follow_Camera>();
    }
    private void Update()
    {
        if(HP<= 0)
        {
            
            follow_Camera.IsLose = true;
            follow_Camera.Target = transform;
            animator.SetTrigger("Destroy");
            Collider2D[] collider2D = FindObjectsOfType<Collider2D>();
            foreach (Collider2D nonaktif in collider2D)
            {
                nonaktif.enabled = false;
            }
        }

    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        health.SetHealth(HP);
    }

    public void DestroyKristal()
    {
        
        Destroy(gameObject);
    }

    public void DestroySound()
    {
        BrokenSound.enabled = enabled;
    }

    public void LoseMenu()
    {
        LoseUi.gameObject.SetActive(true);
    }

}
