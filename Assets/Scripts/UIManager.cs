using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI References (Use Text OR TextMeshPro)")]
    public Text scoreText;
    public Text livesText;
    public GameObject gameOverPanel;
    public Text finalScoreText;
    public Button restartButton;
    
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged += UpdateScore;
            GameManager.Instance.OnLivesChanged += UpdateLives;
            GameManager.Instance.OnGameOverEvent += ShowGameOver;
        }
        
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
        
        UpdateScore(0);
        UpdateLives(3);
    }
    
    void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }
    
    void UpdateLives(int lives)
    {
        if (livesText != null)
        {
            livesText.text = $"Lives: {lives}";
        }
    }
    
    void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        
        if (finalScoreText != null && GameManager.Instance != null)
        {
            finalScoreText.text = $"Final Score: {GameManager.Instance.GetScore()}";
        }
    }
    
    void RestartGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RestartGame();
        }
    }
    
    void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged -= UpdateScore;
            GameManager.Instance.OnLivesChanged -= UpdateLives;
            GameManager.Instance.OnGameOverEvent -= ShowGameOver;
        }
    }
}
