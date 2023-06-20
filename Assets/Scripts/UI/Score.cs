using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;


    void Update()
    {
        //if score is max at 1000, reset it to zero
        if (score == 1000)
        {
            score = 0;
            scoreText.text = "Score: " + score;
        }
    }

    //Increment the score by 1
    public void increaseScore()
    {
        score = score + 1;
        scoreText.text = "Score: " + score;
    }

    //Reset the score variable to zero
    public void resetScore()
    {
        score = 0;
    }


}
