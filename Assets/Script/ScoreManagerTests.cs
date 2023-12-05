using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine;

public class ScoreManagerTests
{
    [Test]
    public void ScoreManager_UpdateBestScores_UpdatesCorrectly()
    {
        ScoreManager.UpdateBestScores(0, 0, 0);

        int testGoldScore = 100;
        int testSilverScore = 50;
        int testBronzeScore = 25;

        ScoreManager.UpdateBestScores(testGoldScore, testSilverScore, testBronzeScore);

        Assert.AreEqual(testGoldScore, ScoreManager.GetBestGoldScore(), "Le score or n'est pas mis à jour correctement.");
        Assert.AreEqual(testSilverScore, ScoreManager.GetBestSilverScore(), "Le score argent n'est pas mis à jour correctement.");
        Assert.AreEqual(testBronzeScore, ScoreManager.GetBestBronzeScore(), "Le score bronze n'est pas mis à jour correctement.");
    }
}
