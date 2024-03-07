using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private Transform player;
   private void  Update()
   {
      transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
   }
   private void OnGUI()
   {
      GUI.Box(new Rect(10, 50, 300, 100), "Main Menu");
      if(GUI.Button(new Rect(70, 70, 100, 50), "Button 1"))
      {
         print("hehe");
      }
   }
}
