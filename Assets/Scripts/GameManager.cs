using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Game Settings")]
    public int maxLives = 3;
    
    private int currentLives;
    private int score;
    private bool gameOver;
    
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
    
    void Start()
    {
        currentLives = maxLives;
        score = 0;
        gameOver = false;
        
        OnLivesChanged?.Invoke(currentLives);
        OnScoreChanged?.Invoke(score);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
