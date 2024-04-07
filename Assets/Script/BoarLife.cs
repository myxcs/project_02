using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BoarLife : MonoBehaviour
{
    private Animator animator;
    
   [SerializeField] public DestroyTheBoar destroyTheBoar;
    public bool boarIsAlive = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
  public void KillTheBoar()
  {
      animator.SetTrigger("death");
      boarIsAlive = false;
      
  }
  public void DesTroyTheBoarz()
  {
     destroyTheBoar.DesTroyTheBoar();
  }
}
