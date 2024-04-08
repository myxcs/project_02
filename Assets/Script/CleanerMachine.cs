using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerMachine : MonoBehaviour
{
    [SerializeField] Transform player;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        transform.position = new Vector3(player.position.x - 20f, transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Grid")
        {
            Destroy(collision.gameObject);
        }
    }
}
