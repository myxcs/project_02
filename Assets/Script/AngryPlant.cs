using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPlant : MonoBehaviour
{
    //Mỗi 3s - bắn ra 1 viên đạn về phía trái
    //Viên đạn phải bay ra từ mồm nó
    //Viên đạn sau khi bay qua camera thì bị xóa đi
    //Người chơi chạy qua Plant, con đó bị xóa đi
    //Người chơi chạm vào đạn thì trừ máu/chết
    //Đặt nó xuất hiện ngẫu nhiên (phía trước nhân vật)

    public GameObject bullet;
    public Transform bulletPos;

    Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("idle");
    }



    public void PlantShoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
    private void OnIdle()
    {
        animator.SetTrigger("idle");
    }
    private void OnShoot()
    {
        animator.SetTrigger("atk");
    }
}
