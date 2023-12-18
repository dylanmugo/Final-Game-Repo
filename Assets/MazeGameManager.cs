using UnityEngine;
using UnityEngine.UI;

public class MazeGameManager : MonoBehaviour
{
    public float timerDuration = 60f;
    private float timer;
    private bool isGameOver = false;

    public Text timerText;
    public Text gameOverMessageText; // Drag the UI Text component here in the Inspector

    void Start()
    {
        timer = timerDuration;
        UpdateTimerDisplay();
        // Deactivate the game over message UI element initially
        if (gameOverMessageText != null)
        {
            gameOverMessageText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay();

            if (timer <= 0f)
            {
                GameOver("Time's up! Quitting...");
            }
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(timer).ToString();
        }
    }

    void GameOver(string message)
    {
        isGameOver = true;
        Debug.Log("Game Over! " + message);

        // Activate the game over message UI element
        if (gameOverMessageText != null)
        {
            gameOverMessageText.text = message;
            gameOverMessageText.gameObject.SetActive(true);
        }

        // Quit the game
        QuitGame();
    }

    void QuitGame()
    {
        // Quit the application in the standalone build
#if UNITY_STANDALONE
        Application.Quit();
#endif

        // Exit Play mode in the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
