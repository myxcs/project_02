using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarController : MonoBehaviour
{
     public SpriteRenderer sprite;
     public Animator animator;
     public Rigidbody2D rb;
     public Transform boar;
    // public Transform posA;
    // public Transform posB;
     public bool isFaceRight = false;
    float speedMove = 3f;
    float timer = 0f;
    float timer2 = 0f;
    float timeBetweenMove = 5f;
    float timeRest = 7f;

    private void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         boar = GetComponent<Transform>();
         animator = GetComponent<Animator>();
         animator.SetTrigger("idle");
         sprite = GetComponent<SpriteRenderer>();
         sprite.flipX = true;
         isFaceRight = true;

    }

    private void Update()
    {
        GoRight();
    }
    private void GoRight()
    {
              timer += Time.deltaTime;
              if(isFaceRight)
              {
                  boar.position = Vector3.MoveTowards(boar.position, new Vector3(boar.position.x + 5f, boar.position.y, 0), speedMove * Time.deltaTime);
                  animator.SetTrigger("running");
                  if(timer > timeBetweenMove)
                  {
                      
                        animator.SetTrigger("idle");
                        rb.bodyType = RigidbodyType2D.Static;
                        timer2 += Time.deltaTime;
                      if(timer2 > timeRest)
                      {
                          
                          timer = 0;
                          timer2 = 0;
                          rb.bodyType = RigidbodyType2D.Dynamic;
                          sprite.flipX = false;
                          isFaceRight = false;
                      }
                  }
                  
              }
              else
              {
                  boar.position = Vector3.MoveTowards(boar.position, new Vector3(boar.position.x + -5f, boar.position.y, 0), speedMove * Time.deltaTime);
                  animator.SetTrigger("running");
                  if(timer > timeBetweenMove)
                  {
                      animator.SetTrigger("idle");
                      rb.bodyType = RigidbodyType2D.Static;
                      timer2 += Time.deltaTime;
                      if(timer2 > timeRest)
                      {
                        
                        timer = 0;
                        timer2 = 0;
                        rb.bodyType = RigidbodyType2D.Dynamic;
                        sprite.flipX = true;
                        isFaceRight = true;
                      }
                  }
              }
          
          
    } 
}

