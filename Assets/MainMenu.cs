using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This method is called when the Play button is clicked.
    public void PlayButton()
    {
        // Load the game scene. Replace "GameScene" with the name of your actual game scene.
        SceneManager.LoadScene("GAME"); 
    }

    // This method is called when the Level Two button is clicked.
    public void LevelTwoButton()
    {
        // Load level two. Replace "LevelTwo" with the name of your level two scene.
        SceneManager.LoadScene("LevelTwo");
    }

    // This method is called when the Quit button is clicked.
    public void QuitButton()
    {
        // Quit the application in the standalone build.
#if UNITY_STANDALONE
        Application.Quit();
#endif

        // Exit Play mode in the editor.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
