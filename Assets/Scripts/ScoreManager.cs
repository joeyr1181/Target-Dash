using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    // ScoreManager script to handle scoring and high score management
    // Singleton instance for easy access
    // UI Text components for displaying score and high score
    // Timer for the game, counting down from a set time
    // Score and high score variables
    // Timer variables to manage the countdown
    public static ScoreManager Instance;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text timerText; // Add this for the timer UI

    private int score = 0;
    private int highScore = 0; // High score variable to keep track of the highest score

    public float timeRemaining = 10f; // 10 seconds timer for testing
    private bool timerIsRunning = false;


    // Awake is called when the script instance is being loaded
    // Initialize the singleton instance and load high score from PlayerPrefs
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

    // Start is called before the first frame update
    // Start the timer when the game starts
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    // Update the timer and check if it has reached zero
    // If the timer reaches zero, stop it and call GameOver
    // Update the score text UI
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

    // Method to add score
    // Increment the score by a specified amount
    // Update the score text UI
    // If the score exceeds the high score, update the high score and save it to PlayerPrefs
    // Update the high score text UI
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

    // Method to update the high score text UI
    // This is called whenever the high score is updated
    // Update the text to display the new high score
    private void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }

    // Method to handle game over logic
    // This can be expanded to include more game over logic, such as showing a game over screen
    private void GameOver()
    {
        Debug.Log("Game Over! Time's up!");

    }
}
