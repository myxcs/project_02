using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform player;
    public GameObject coin;

    bool enableSpawn;

    private void Start()
    {
        enableSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Nếu mà enableSpawn = true -> thì cho phép sinh coin
        if (enableSpawn)
        {
            enableSpawn = false;

            float viTriX = player.position.x + Random.Range(15f, 30f);
            float viTriY = Mathf.Sin(viTriX) + 0.5f;

            int soLuong = Random.Range(25, 59);

            for (int i = 0; i < soLuong; i++)
            {
                //Sinh ra coin, ở vị trí nào, hướng xoay (không đổi), làm con của đối tượng nào
                Instantiate(coin, new Vector3(viTriX, viTriY, 0), Quaternion.identity, transform);
                viTriX ++;
                viTriY = Mathf.Sin(viTriX) + 0.5f;
            }

            StartCoroutine(DelayForSpawn());
        }
    }

    IEnumerator DelayForSpawn()
    {
        float timer = Random.Range(10f, 15f);
        yield return new WaitForSeconds(timer);
        enableSpawn = true;
    }
}
