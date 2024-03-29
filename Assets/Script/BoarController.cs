using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarController : MonoBehaviour
{
    public SpriteRenderer sr;
    public Animator anim;

    public Transform boar;
    public Transform posA;
    public Transform posB;

    bool isFaceRight = true;
    float speedMove = 3f;

    private void Update()
    {
        if (isFaceRight) //nó đang đi sang phải -> posB
        {
            if (Vector2.Distance(boar.position, posB.position) > 0.1f)
            {
                boar.position = Vector3.MoveTowards(boar.position, posB.position, speedMove * Time.deltaTime);
                anim.Play("Boar_Running");
            }
            else
            {
                isFaceRight = false;
                sr.flipX = false;
            }
        }
        else //nó đang đi trang trái -> posA
        {
            if (Vector2.Distance(boar.position, posA.position) > 0.1f)
            {
                boar.position = Vector3.MoveTowards(boar.position, posA.position, speedMove * Time.deltaTime);
                anim.Play("Boar_Running");
            }
            else
            {
                isFaceRight = true;
                sr.flipX = true;
            }
        }
    }
}
