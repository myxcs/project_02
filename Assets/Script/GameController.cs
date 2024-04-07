using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public ItemCollector itemCollector;
   

    

  
       public void GameOver()
    {
        gameOverScreen.Setup(itemCollector.coins);
    }


}
