using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int currentScore;
    public int maxScore = 50;
    private bool isWin = false;

    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScore >= 50)
        {
            isWin = true;

        }
    }

    public void addScore(int score)
    {
        currentScore =+ score ;
    }

}
