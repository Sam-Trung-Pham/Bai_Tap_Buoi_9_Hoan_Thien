using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public PlayerHealth playerHealth;
    [SerializeField] private Text locationText;//hien thi va cham voi doi tuong nao
    public AudioSource collectSound;//doi tuong quan ly am thanh
    private bool hitStone = true;//kiem tra xem co va vaof Stone
    public AudioSource Gov;
    public AudioSource Run;
    public GameObject gameoverPanel;
    public GameObject playerObject;
    //dinh nghia ham xu ly va cham
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag=="Coin")//va cham coin
        {
            //bat am thanh
            collectSound.Play();
            hit.gameObject.GetComponent<Coin>().Dead();
            //tang 1 diem
            GetComponent<ScoreManager>().TangDiem(1);
        }
        if(hit.gameObject.tag=="Stone")//neu va phai da
        {
            if(hitStone)
            {
                //dua vao khoi lap de xu ly bang cach goi khoi lap
                StartCoroutine(EnableCollider(hit, 1));//goi da tien trinh
            }
        }
        //cap nhat text
        if(hit.gameObject.tag=="MushroomLocation")
        {
            locationText.text = "Va Cham Voi: Mushroom";
            TakeDamage(20);
        }
        if (hit.gameObject.tag == "StoneLocation")
        {
            locationText.text = "Va Cham Voi: Stone";
            TakeDamage(20);
        }
        if (hit.gameObject.tag == "FireLocation")
        {
            locationText.text = "Va Cham Voi: Fire";
            TakeDamage(20);
        }
        if (hit.gameObject.tag == "HouseLocation")
        {
            locationText.text = "Va Cham Voi: House";
        }
        if (hit.gameObject.tag == "Nền")
        {
            locationText.text = "Bạn đang ở trên nền";
        }
        if (hit.gameObject.tag == "Tree")
        {
            locationText.text = "Va Cham Voi: Cây";
        }
        if (hit.gameObject.tag == "road")
        {
            locationText.text = "Bạn đang đi ";
        }
    }
    //dinh ngia ham goi khoi lam yield
    private IEnumerator EnableCollider(ControllerColliderHit hit, float second)
    {
        hitStone = false;
        yield return new WaitForSeconds(second);//khoi lap
        hitStone = true;
    }
    void Start()
    {
        currentHealth = maxHealth;
        playerHealth.SetMaxHealth(maxHealth);
        gameoverPanel.SetActive(false);
        playerObject = gameObject;
    }

   
    void Update()
    {
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerHealth.SetHealth(currentHealth);
        if (currentHealth<=0)
        {
            ShowGameOverPanel();
            Gov.Play();
            Run.Stop();
        }
    }
    void ShowGameOverPanel()
    {
        gameoverPanel.SetActive(true);
        this.enabled = false;
        Destroy(playerObject);
    }
}
