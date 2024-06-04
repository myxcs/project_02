using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comment : MonoBehaviour
{
    [SerializeField] GameObject boom;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
        int rd = Random.Range(1, 4);
        switch(rd)
        {
            case 1:
            Instantiate(boom, pos1.position, Quaternion.identity); break;
            case 2:
            Instantiate(boom, pos2.position, Quaternion.identity); break;
            case 3:
            Instantiate(boom, pos3.position, Quaternion.identity); break;
        }
       }


        if(Input.GetKeyDown(KeyCode.B))
        {
            GameObject[] getAllEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            if(getAllEnemy.Length > 0)
            {
                foreach(GameObject item in getAllEnemy)
                {
                    Destroy(item);
                }
            }

        }

    }
    
}
