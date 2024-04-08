using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Text pointsText;
    public Text HighScoreText;
    //public ItemCollector itemCollector;
    
    
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";

        int highScore = PlayerPrefs.GetInt("Highscore", 0);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
        HighScoreText.text = "HIGHSCORE: " + highScore.ToString();

    }
     public void Restart()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReturnHome()
    {
        SceneManager.LoadScene("Scenes01");
    }

  
}
