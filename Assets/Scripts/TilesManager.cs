using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    public GameObject[] tilesPrefabs;//mang chua template dia hinh
    private List<GameObject> activeTiles;//mang dia hinh hieu dung
    private float vitriZ = 0f;//vi tri theo truc Z
    private float tileLength = 44f;//chieu dai dia hinh
    private int tilesOnScreen;//so luong dia hinh hien thi dong thoi tren man hinh
    private Transform player;//nhan vat
    private void TaoDiaHinh(int i=-1)
    {
        GameObject g;
        if(i==0)//chua co dia hinh
        {
            g = Instantiate(tilesPrefabs[0]);//tao dia hinh voi prefabs 0
        }
        else //neu da co dia hinh, tao ngau nhien 1 dia hinh
        {
            g = Instantiate(tilesPrefabs[Random.Range(1,tilesPrefabs.Length)]);
        }
        //dua vao dia hinh cha
        g.transform.SetParent(transform);
        //cap nhat lai vi tri
        g.transform.position = Vector3.forward * vitriZ;
        vitriZ += tileLength;//cong them voi chieu dai dia hinh
        //dua dia hinh vao list
        activeTiles.Add(g);

    }
    private void XoaDiaHinh()
    {
        Destroy(activeTiles[0]);//huy
        activeTiles.RemoveAt(0);//xoa khoi mang
    }

    void Start()
    {
        //anh xa nhan vat
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //khoi tao mang dia hinh hieu dung
        activeTiles = new List<GameObject>();
        //su dung vong lap de sinh dia hinh
        for(int i=0;i<tileLength;i++)
        {
            if (i < 1)//neu chua co dia hinh thi can tao dia hinh dau tien
            {
                TaoDiaHinh(0);
            }
            else//neu da co thi ta tao dia hinh ngau nhien
            {
                TaoDiaHinh();
            }
        }
    }

    
    void Update()
    {
        //kiem tra dieu kien tao, huy dia hinh
        if((player.position.z-tileLength)>(vitriZ-tileLength*tilesOnScreen))
        {
            TaoDiaHinh();//khi nhan vat den
            XoaDiaHinh();//khi nhan vat di
        }
    }
}
