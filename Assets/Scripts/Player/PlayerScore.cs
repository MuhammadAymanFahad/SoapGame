using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int currentScore;
    public int maxScore = 40;
    public TMP_Text scoreText;

    void Start()
    {
        currentScore = 0;
        scoreText.text = "Your Score : " + 0;
    }

    public int getCurrentScore()
    {
        return this.currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        changeScore();
    }

    public void addScore(int score)
    {
        currentScore += score ;
    }

    public void changeScore()
    {
        scoreText.text = "Your Score : " + currentScore.ToString();
    }
}
