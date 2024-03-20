using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    //[SerializeField] private AudioSource deathSoundEffect;
   
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Traps")
        {
            Debug.Log("-10");
            TakeDamage(20);
        }
    }

    private void TakeDamage(int damage)
    {
       currentHealth -=damage;
       
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }

     private void Die()
    {

       // deathSoundEffect.Play();
        anim.SetTrigger("death");
        Debug.Log("Game Over");
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}