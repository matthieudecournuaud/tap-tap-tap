using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject gameOverCanvasPrefab;
    public GameObject menuCanvasPrefab;
    private GameObject gameOverCanvas;
    private GameObject menuCanvas;
    public const string LastPlayedLevelKey = "LastPlayedLevelIndex";
    private bool isGamePaused = false;

    public bool IsGamePaused
    {
        get { return isGamePaused; }
    }

    public event System.Action<bool> OnGamePaused;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameOverCanvas = GameObject.Find("Game Over Canvas") ?? Instantiate(gameOverCanvasPrefab);
        menuCanvas = GameObject.Find("Menu Canvas") ?? Instantiate(menuCanvasPrefab);

        SetupCanvasButtons(); // Configurer les boutons après l'instanciation

        gameOverCanvas.SetActive(false);
        menuCanvas.SetActive(false);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void GameOver()
    {
        if (gameOverCanvas == null)
        {
            return;
        }

        gameOverCanvas.SetActive(true);
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(true);
        }
        Time.timeScale = 0;
    }


    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        OnGamePaused?.Invoke(isGamePaused);
        Time.timeScale = isGamePaused ? 0 : 1;
    }

    public void ToMenuing()
    {
        SceneManager.LoadScene("Menuing");
    }

    public void MenuingLevel()
    {
        SceneManager.LoadScene("MenuLevels");
    }

    public void ToMenuRecord()
    {
        SceneManager.LoadScene("MenuRecords");
    }

    public void ResetGame()
    {
        Score.score = 0;
        isGamePaused = false;
        Time.timeScale = 1;
        gameOverCanvas.SetActive(false);
        menuCanvas.SetActive(false);
    }

    public void LoadLevelByNumber(int levelNumber)
    {
        SetLastPlayedLevel(levelNumber);
        string sceneName = "Scene-niveau " + levelNumber;
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    private void SetupCanvasButtons()
    {
        Button replayButton = gameOverCanvas.GetComponentInChildren<Button>(true);
        if (replayButton != null)
        {
            replayButton.onClick.RemoveAllListeners();
            replayButton.onClick.AddListener(Replay);
        }

        Button menuButton = menuCanvas.GetComponentInChildren<Button>(true);
        if (menuButton != null)
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(ToMenuing);
        }
    }

    public void SetLastPlayedLevel(int level)
    {
        PlayerPrefs.SetInt(GameManager.LastPlayedLevelKey, level);
        PlayerPrefs.Save();
        Time.timeScale = 1;
    }

    public void LoadLastPlayedLevel()
    {
        int level = PlayerPrefs.GetInt("LastPlayedLevelIndex", 0);
        SceneManager.LoadScene(level);
    }
}
