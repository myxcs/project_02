using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class GameManager : MonoBehaviour
{
    public Text tilte;
    public Text lilMa;
    public Button play;
    public Button quit;
  
    // Start is called before the first frame update
    public void Start()
    {
        tilte.text = "Hopeless Runner 0.1";
        lilMa.text = "by myXcs";
        play.GetComponentInChildren<Text>().text = "Go!";
        quit.GetComponentInChildren<Text>().text = "Quit!";
        
    }

}
