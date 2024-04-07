using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarController : MonoBehaviour
{
   public Transform[] patrolPoints;
   public float moveSpeed = 3;
   public int patrolDestination = 0;
   
   public SpriteRenderer sprite;
   private bool isFaceRight = true;
   private Animator animator;
   private Rigidbody2D rb;

   private float timer = 0f;
   public float coolDown = 2f;
   public BoarLife boarLife;

    // Start is called before the first frame update
    private void Start()
    {
        patrolDestination = 0;
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("run", true);
    }

    // Update is called once per frame
   private void Update()
    {
        if(boarLife.boarIsAlive)
        {
            BoarPatrol();
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
       

}

    private void BoarPatrol()
    {
      if(patrolDestination == 0)
        {

           
            if(animator.GetBool("run") == true){
                   transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            }
            if(Vector2.Distance (transform.position, patrolPoints[0].position) < 0.2f)
            {
                
               
                animator.SetBool ("run", false);
                 timer += Time.deltaTime;
                if(timer >= coolDown)
                {
                    timer = 0f;
                    sprite.flipX = isFaceRight;
                    animator.SetBool ("run", true);
                     patrolDestination = 1;
                }
               
            }
        }

        if(patrolDestination == 1)
        {
           
             if(animator.GetBool("run") == true){
                   transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            }
            if(Vector2.Distance (transform.position, patrolPoints[1].position) < 0.2f)
            {
                
                 animator.SetBool ("run", false);

                 timer += Time.deltaTime;
                if(timer >= coolDown)
                {
                    timer = 0f;
                    sprite.flipX = !isFaceRight;
                    animator.SetBool ("run", true);
                    patrolDestination = 0;
                }
        }
     }
    }
}

