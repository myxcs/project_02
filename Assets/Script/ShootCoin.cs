using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCoin : MonoBehaviour
{
    public GameObject coin;
    public Transform coinPos;
    public ItemCollector itemCollector;
    public int howManyBullet;
    public bool isShot;
     
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {

    }
        void Update()
    {
        howManyBullet = itemCollector.coins;
        if(Input.GetKeyDown("f"))
        {
            if(howManyBullet > 0)
            {
            Debug.Log("Shooting");
            Instantiate(coin, coinPos.position, Quaternion.identity);
            howManyBullet--;
            itemCollector.coins = howManyBullet;
            }
            else
            {
                Debug.Log("I need more bullets");
            }
        } 
    }
    
}
