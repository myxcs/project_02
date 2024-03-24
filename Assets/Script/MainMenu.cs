using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes02");
    }

    public void PlayGround()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes03");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
