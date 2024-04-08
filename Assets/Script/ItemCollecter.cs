using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int coins = 0;

    [SerializeField] private Text coinText;
    [SerializeField] private AudioSource collectionSoundEffect;
    public ShootCoin shootCoin;


    
    //tạo trigger
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coins"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            coins++;
            
            Debug.Log("Coins: " + coins);
          // PlayerPrefs.SetInt("HighScore", coins);
            
        }
    }
    void Update()
    {
        coinText.text = "Coins: " + coins;
    }
}
