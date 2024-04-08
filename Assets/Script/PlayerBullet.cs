using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed = 10f;
    public Transform transf;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transf = GetComponent<Transform>();
       // Destroy(gameObject,3f);
    }

    // Update is called once per frame
    void Update()
    {
         rb.velocity = new Vector2(15f, rb.velocity.y);
    }    
  
}
