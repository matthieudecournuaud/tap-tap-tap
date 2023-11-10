using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score.score++; // Supposons que "score" soit le score actuel atteint par le joueur

        // Récupérez les meilleurs scores actuels
        int bestGoldScore = ScoreManager.GetBestGoldScore();
        int bestSilverScore = ScoreManager.GetBestSilverScore();
        int bestBronzeScore = ScoreManager.GetBestBronzeScore();

        // Comparez le score actuel avec les meilleurs scores et mettez à jour si nécessaire
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
