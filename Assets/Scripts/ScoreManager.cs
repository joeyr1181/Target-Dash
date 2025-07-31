using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text timerText; // Add this for the timer UI

    private int score = 0;
    private int highScore = 0;

    public float timeRemaining = 10f; // 10 seconds timer for testing
    private bool timerIsRunning = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Load high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }

    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerText.text = "Time: 0";
                timerIsRunning = false;
                GameOver();
            }
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }
    }

    private void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over! Time's up!");
        // TODO: Add game over logic here, e.g. disable player input, show Game Over UI, etc.
    }
}
