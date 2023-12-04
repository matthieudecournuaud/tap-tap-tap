using UnityEngine;
using TMPro;

public class BestScoresDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreOrText;
    public TextMeshProUGUI scoreArgentText;
    public TextMeshProUGUI scoreBronzeText;

    private void Start()
    {
        // Obtenir les meilleurs scores depuis le ScoreManager
        int bestGoldScore = ScoreManager.GetBestGoldScore();
        int bestSilverScore = ScoreManager.GetBestSilverScore();
        int bestBronzeScore = ScoreManager.GetBestBronzeScore();

        // Mettre à jour le texte des TextMeshPro
        scoreOrText.text = bestGoldScore.ToString();
        scoreArgentText.text = bestSilverScore.ToString();
        scoreBronzeText.text = bestBronzeScore.ToString();
    }
}
