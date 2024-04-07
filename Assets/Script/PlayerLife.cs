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
    public BoxCollider2D bc;

    

    public int maxHealth = 100;
    public int currentHealth;


    public HealthBar healthBar;
    public GameObject healthBarObject;
    public GameController gameController;
    public BoarController boarController;
    public PlayerMovement playerMovement;
    public bool boarHit;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource hitSoundEffect;
   
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBarObject = GameObject.Find("HealthBar");
        bc = GetComponent<BoxCollider2D>();
        boarHit = true;
        
    }

    public void Update()
    {
        boarHit = boarController.getHit;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Traps")
        {
            Debug.Log("-10");
            
            TakeDamage(20);
            hitSoundEffect.Play();
        }
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log(-20);
            boarHit = true;
           boarController.getHit = true;
             playerMovement.KBCounter = playerMovement.KBTotalTime;
             if(collision.transform.position.x <= player.position.x)
             {
                 playerMovement.KnockFromRight = true;
             }
             if(collision.transform.position.x > player.position.x)
             {
                 playerMovement.KnockFromRight = false;
             }
            TakeDamage(20);
            hitSoundEffect.Play();
        }
        if(collision.gameObject.tag == "Deadzone")
        {
            Debug.Log("Die");
            //Die();

        }
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "Bullet")
        {
            Debug.Log(-20);
            TakeDamage(20);
            hitSoundEffect.Play();
            Destroy(trigger.gameObject);
        }
    }
    


    

    public void TakeDamage(int damage)
    {
       currentHealth -=damage;
       
        healthBar.SetHealth(currentHealth);
       
        
        if(currentHealth <= 0)
        {
            gameController.GameOver();
            Die();
        }
    }
     public void Die()
    {
        deathSoundEffect.Play();
        anim.SetTrigger("death");
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        bc.enabled = false;
        healthBarObject.SetActive(false);
       // RestartLevel();
    }

}