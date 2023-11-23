using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text levelText;

    public static float score = 0f;

    private int maxLevel = 10;

    private int level = 1;

    private int scoreToNextLevel = 10;

    private bool isDead = false;

    internal void Dead()
    {
        isDead = true;
    }

    public void TangDiem(float s)
    {
        score += s;
    }

    void TangLevel()
    {
        if (level==maxLevel)// nếu là level lớn nhất
            return;
            scoreToNextLevel = scoreToNextLevel * 2;
            ++level;
            GetComponent<PlayerRunning>().SetSpeed(level);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)//new không phải trạng thái chết
        {
            if (score > scoreToNextLevel)
            {
                TangLevel();
            }

            scoreText.text = "Score:" + ((int)score).ToString();
            levelText.text = "Level:" + level;
        }
    }
}
