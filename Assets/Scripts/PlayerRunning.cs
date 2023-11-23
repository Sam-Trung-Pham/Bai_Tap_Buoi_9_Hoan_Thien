using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    private bool isDead = false;//kiem tra trang thai chet
    private float YVelocity = 0f;//van toc theo truc y
    private float gravity = 9.8f;//gia toc
    private Vector3 moveVector;//vec to di chuyen
    private CharacterController player;//nhan vat
    private float animTime = 2f;//thoi gian animation
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float jumpForce=8f;
    private void Awake()//khởi tạo các biến
    {
        player = GetComponent<CharacterController>();//anh xa
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(Time.time<animTime)
        {
            player.Move(Vector3.forward * speed * Time.deltaTime);//di chuyen
        }
        else
        {
            if (!isDead)
            {
                if (player.isGrounded)
                {
                    YVelocity = -0.5f;
                    if (Input.GetKey(KeyCode.Space))
                    {
                        YVelocity = jumpForce;
                    }
                }
                else
                {
                    YVelocity -= gravity * Time.deltaTime;
                }
                // Chuyển động từng thành phần
                moveVector.x = Input.GetAxis("Horizontal") * speed;
                moveVector.z = speed;
                moveVector.y = YVelocity;

                // Tổng hợp
                player.Move(moveVector * Time.deltaTime);
            }
        }
    }
    public void SetSpeed(float s)//ham thay doi toc do
    {
        speed += s;
    }
    internal void Dead()//kiem tra trang thai chet
    {
        isDead = true;
    }

    
}
