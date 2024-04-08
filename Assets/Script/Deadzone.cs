using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    [SerializeField] Transform player;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        transform.position = new Vector3(player.position.x, -5 , transform.position.z);
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         other.gameObject.GetComponent<PlayerLife>().TakeDamage(100);
    //         Debug.Log("Deadzone");
            
    //     }
    // }
}
