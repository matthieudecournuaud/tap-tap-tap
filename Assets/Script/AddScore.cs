using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score.score++; 

        int bestGoldScore = ScoreManager.GetBestGoldScore();
        int bestSilverScore = ScoreManager.GetBestSilverScore();
        int bestBronzeScore = ScoreManager.GetBestBronzeScore();

        if (Score.score > bestGoldScore)
        {
            ScoreManager.UpdateBestScores(Score.score, bestSilverScore, bestBronzeScore);
        }
        else if (Score.score > bestSilverScore)
        {
            ScoreManager.UpdateBestScores(bestGoldScore, Score.score, bestBronzeScore);
        }
        else if (Score.score > bestBronzeScore)
        {
            ScoreManager.UpdateBestScores(bestGoldScore, bestSilverScore, Score.score);
        }
    }
}
