using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarLife : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
  public void KillTheBoar()
  {
      animator.SetTrigger("death");
  }
  public void DesTroyTheBoar()
  {
    Destroy(gameObject);
  }
}
