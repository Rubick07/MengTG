using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject LoseUi;
    public int MaxHealth;
    public int CurrentHealth;
    public HealthBar healthBar;
    public Animator animator;

    private Player player;
    private Player_Input player_input;
    private CapsuleCollider2D capsuleCollider;
    private BoxCollider2D boxCollider;
    private void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        player = GetComponent<Player>();
        player_input = GetComponent<Player_Input>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void Update()
    {
        if(CurrentHealth <= 0)
        {
            Follow_Camera camera = FindObjectOfType<Follow_Camera>().GetComponent<Follow_Camera>();
            camera.IsLose = true;
            animator.SetTrigger("Death");
            player.enabled = false;
            player_input.enabled = false;
            capsuleCollider.enabled = false;
            boxCollider.enabled = false;
            Collider2D []collider2D = FindObjectsOfType<Collider2D>();
            foreach(Collider2D nonaktif in collider2D)
            {
                nonaktif.enabled = false;
            }

        }
    }


    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        healthBar.SetHealth(CurrentHealth);
    }

    public void Lose()
    {
        LoseUi.SetActive(true);
    }


}
