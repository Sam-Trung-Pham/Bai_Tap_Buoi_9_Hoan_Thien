using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private MeshCollider meshCollider;//collider xu ly va cham
    private void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();//anh xa
    }
    void Start()
    {
        
    }

    // xoay tron doi tuonh
    void Update()
    {
        transform.Rotate(Vector3.right, 3);
    }
    //huy doi tuong
    public void Dead()
    {
        Destroy(gameObject);
    }
}
