using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public Transform player;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource hitSoundEffect;
   
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
            hitSoundEffect.Play();
        }
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("-10");
            TakeDamage(10);
            hitSoundEffect.Play();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Deadzone")
        {
            Debug.Log("Die");
            //Die();

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
    private void RestartLevel()
    {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     public void Die()
    {

        deathSoundEffect.Play();
        anim.SetTrigger("death");
        Debug.Log("Game Over");
        rb.bodyType = RigidbodyType2D.Static;
       // RestartLevel();
    }

    
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
//    private void Update()
//     {
//         if(player.position.y < -5f)
//         {
//             RestartLevel();
//         }
//     }
}