using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    [SerializeField] private GameObject boar;
    
  
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
           boar.GetComponent<BoarLife>().KillTheBoar();
           Debug.Log("You killed the boar");
        }
    }
}
