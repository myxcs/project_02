using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int coins = 0;

    [SerializeField] private Text coinText;
    [SerializeField] private AudioSource collectionSoundEffect;
    public ShootCoin shootCoin;
    public int currenHealth;
    


     /// <summary>
     /// Start is called on the frame when a script is enabled just before
     /// any of the Update methods is called the first time.
     /// </summary>
     void Start()
     {
           currenHealth = GameObject.Find("Player").GetComponent<PlayerLife>().currentHealth;
     }
    
    //tạo trigger
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coins"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            coins++;
          
            currenHealth += 10;
            
            
            
            
            
            Debug.Log("Coins: " + coins);
          // PlayerPrefs.SetInt("HighScore", coins);
            
        }
    }
    void Update()
    {
        coinText.text = "Coins: " + coins;
    }
}
