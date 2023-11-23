using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 moveVector;//vec to di chuyen
    private Vector3 distance;//khoang cach tu camera den nhan vat
    private Vector3 positionBase;//vi tri ban dau
    private float condition = 0f;
    private void Awake()
    {
        //anh xa
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //khoi tao bien
        positionBase = new Vector3(0, 5, 5);//khoi tao vi tri ban dau cua camera
        distance = transform.position - player.position;//khoang cach
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = player.position + distance;//cap nhat vector di chuyen
        //theo toa do
        moveVector.x = 0f;//khong cho camera di chuyen theo chieu ngang
        moveVector.y = Mathf.Clamp(moveVector.y, 3f, 5f);//camera cua truc y thay doi tu 3-5
        if(condition >1f)//dieu kien gan camera bang vector di chuyen
        {
            transform.position = moveVector;
        }
        else
        {
            //cap nhat vi tri moi cho camera
            transform.position = Vector3.Lerp(moveVector + positionBase,
                moveVector, condition);//camera di chuyen
            condition += 0.5f * Time.deltaTime;//thay doi dieu kien follow
            transform.LookAt(player.position);//follow
        }
    }
}
