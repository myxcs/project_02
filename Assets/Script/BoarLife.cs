using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BoarLife : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AudioSource boarDeath;
    
   [SerializeField] public DestroyTheBoar destroyTheBoar;
    public bool boarIsAlive = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void  OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "PlayerBullet")
        {
            KillTheBoar();
        }
    }
    public void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerBullet")
        {
            KillTheBoar();
        }
    }
  public void KillTheBoar()
  {
      animator.SetTrigger("death");
      boarDeath.Play();
      boarIsAlive = false;
      
  }
  public void DesTroyTheBoarz()
  {
     destroyTheBoar.DesTroyTheBoar();
  }
}
