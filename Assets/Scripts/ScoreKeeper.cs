using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
   private int currentScore;

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score Add: " +  score + ". Total score: " + currentScore); 
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void Reset()
    {
        currentScore = 0;
        Debug.Log("Score reset to zero.");
    }

}
