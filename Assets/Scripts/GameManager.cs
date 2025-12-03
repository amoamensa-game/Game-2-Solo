using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Game Settings")]
    public int maxLives = 3;
    
    [Header("Audio")]
    public AudioSource backgroundMusic;
    
    [Header("UI References")]
    public GameObject startGamePanel;

    private int currentLives;
    private int score;
    private bool gameOver;
    private bool gameStarted;
    
    public System.Action<int> OnScoreChanged;
    public System.Action<int> OnLivesChanged;
    public System.Action OnGameOverEvent;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartGame();
        }
    }

    void Start()
    {
        currentLives = maxLives;
        score = 0;
        gameOver = false;
        gameStarted = false;
        
        Time.timeScale = 0f;
        
        if (startGamePanel != null)
        {
            startGamePanel.SetActive(true);
        }
        
        OnLivesChanged?.Invoke(currentLives);
        OnScoreChanged?.Invoke(score);
    }
    
    public void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1f;
        
        if (startGamePanel != null)
        {
            startGamePanel.SetActive(false);
        }
    }
    
    public bool IsGameStarted()
    {
        return gameStarted;
    }
    
    public void AddScore(int points)
    {
        if (gameOver) return;
        
        score += points;
        OnScoreChanged?.Invoke(score);
    }
    
    public void LoseLife()
    {
        if (gameOver) return;
        
        currentLives--;
        OnLivesChanged?.Invoke(currentLives);
        
        if (currentLives <= 0)
        {
            GameOver();
        }
    }
    
    void GameOver()
    {
        gameOver = true;
        
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }
        
        OnGameOverEvent?.Invoke();
        Debug.Log($"Game Over! Final Score: {score}");
    }
    
    public bool IsGameOver()
    {
        return gameOver;
    }
    
    public int GetScore()
    {
        return score;
    }
    
    public int GetLives()
    {
        return currentLives;
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
