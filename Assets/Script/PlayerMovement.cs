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
    private float dirX;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask jumpableGround;
    private BoxCollider2D coll;


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
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void UpdateAnimation()
    {
        if (dirX > 0)
        {
            sprite.flipX = false;
            anim.SetBool("running",true);
        }
        else if (dirX < 0)
        {
            anim.SetBool("running",true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running",false);
        }
        }

}
