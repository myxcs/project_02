using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform player;
    public GameObject coin;
    public float spawnTime = 1f;
    public float spawnDelay = 1f;
   bool enableSpawn = true;
    // Start is called before the first frame update
    private void Update() {
        if(enableSpawn == true)
        {
            enableSpawn = false;
            float positionX = player.position.x + Random.Range(-10, 10);
            float positionY = player.position.y + Random.Range(-10, 10);

            Instantiate(coin, new Vector2(positionX, positionY), Quaternion.identity);
            Invoke("EnableSpawn", spawnDelay);
            
        }
    }
    void EnableSpawn()
    {
        enableSpawn = true;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player")
        {
            enableSpawn = false;    
        }
    }
}
