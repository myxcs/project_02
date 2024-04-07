using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public bool isFaceRight;

    [SerializeField] PlayerMovement face;
   
    [SerializeField]Transform castPoint;

    [SerializeField] private float timer;

    bool iNeedMoreBullet = false;


    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
       if(Input.GetKeyDown("e"))
       {
          iNeedMoreBullet = true;
          //ShootRayCast();
          Debug.Log("Shoot");
       }
       if(iNeedMoreBullet)
       {
        timer += Time.deltaTime;
        ShootRayCast();
       if(timer >= 1f)
         {
           iNeedMoreBullet = false;
           timer = 0f;
         }
       }

    }

    private void ShootRayCast()
    {
        float castDist;
        if(face.playerFaceRight)
        {
             castDist = 10f;
        }
        else
        {
            castDist = -10f;
        }
        Vector2 endPos = castPoint.position + Vector3.right * castDist;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Enemy"));
        if(hit.collider != null)
        {   
           // Debug.Log(hit.collider.name);
            if(hit.collider.name == "BoarBody")
            {
               hit.collider.GetComponent<BoarLife>().KillTheBoar();
            }
            Debug.DrawLine(castPoint.position, endPos, Color.red);
        }
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);
        }

    }
}
