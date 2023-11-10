using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Variables pour stocker les meilleurs scores
    private static int bestGoldScore = 0;
    private static int bestSilverScore = 0;
    private static int bestBronzeScore = 0;

    // Mettez à jour les meilleurs scores
    public static void UpdateBestScores(int goldScore, int silverScore, int bronzeScore)
    {
        if (goldScore > bestGoldScore)
        {
            bestGoldScore = goldScore;
        }

        if (silverScore > bestSilverScore)
        {
            bestSilverScore = silverScore;
        }

        if (bronzeScore > bestBronzeScore)
        {
            bestBronzeScore = bronzeScore;
        }
    }

    // Obtenez les meilleurs scores
    public static int GetBestGoldScore()
    {
        return bestGoldScore;
    }

    public static int GetBestSilverScore()
    {
        return bestSilverScore;
    }

    public static int GetBestBronzeScore()
    {
        return bestBronzeScore;
    }
}
