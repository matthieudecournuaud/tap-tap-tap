using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButtonManager : MonoBehaviour
{
    public void OnReplayButtonPressed()
    {
        GameManager.Instance.Replay();
    }

    public void OnMenuButtonPressed()
    {
        // Appelez la méthode SetLastPlayedLevel de GameManager pour enregistrer le niveau actuel
        GameManager.Instance.SetLastPlayedLevel(SceneManager.GetActiveScene().buildIndex);

        // Ensuite, chargez le menu principal
        GameManager.Instance.ToMenuing();
    }

    public void OnLevelButtonClicked(int level)
    {
        GameManager.Instance.LoadLevelByNumber(level);
    }

    public void OnMenulevelButtonPressed()
    {
        GameManager.Instance.MenuingLevel();
    }

    public void OnMenuRecordButtonPressed()
    {
        GameManager.Instance.ToMenuRecord();
    }

    public void OnBackToPlayButtonPressed()
    {
        GameManager.Instance.LoadLastPlayedLevel();
    }

    public void BackToMenuing()
    {
        GameManager.Instance.ToMenuing();
    }
    // Ajoutez d'autres méthodes au besoin pour d'autres boutons
}
