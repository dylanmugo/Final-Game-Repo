using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    private int score = 0;
    private int highScore = 0;

    void Start()
    {
        // Initialize the UI text elements
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    // Call this method to increase the player's score
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreUI();

        // You can add additional logic here, such as checking for a new high score
        CheckForHighScore();
    }

    // Update the UI text elements with the current score values
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Check if the current score is a new high score
    void CheckForHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    // Reset the score to zero
    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    // Call this method when the player collects a key
    public void CollectKey(int keyScore)
    {
        IncreaseScore(keyScore);
        // You can add additional key collection logic here
    }
}
