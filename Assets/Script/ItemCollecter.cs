using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0;
    [SerializeField] private Text coinText;
    [SerializeField] private AudioSource collectionSoundEffect;
    //tạo trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coins"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            coins++;
            coinText.text = "Coins: " + coins;
            Debug.Log("Coins: " + coins);
            
        }
    }
}
