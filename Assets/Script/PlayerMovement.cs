using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed = 5f;
    private float jumpForce = 7f;
    public float dirX;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;
   // public bool KnockFromLeft;
    

    public bool playerFaceRight;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect;
    private BoxCollider2D coll;

    private enum MovementState { idle, running, jumping, falling };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim =GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        //dirX = 1f;
        if (KBCounter <=0)
        {
             rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
        else
        {
            if (KnockFromRight)
            {
                rb.velocity = new Vector2(KBForce, 1f);
            }
            else
            {
                rb.velocity = new Vector2(-KBForce, 1f);
            }
            KBCounter -= Time.deltaTime;
        }
       

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }


    public void StartRay(){
        
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void UpdateAnimation()
    {
        MovementState state = MovementState.idle;
        if (dirX > 0)
        {
            sprite.flipX = false;
            state = MovementState.running;
            playerFaceRight = true;
        }
        else if (dirX < 0)
        {
            sprite.flipX = true;
            state = MovementState.running;
            playerFaceRight = false;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
         {
            state = MovementState.falling;
         }
         anim.SetInteger("state", (int)state);

    }

}
