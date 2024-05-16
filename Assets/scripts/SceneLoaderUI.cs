using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Scene names for different functionalities
    public string startGameScene;
    public string settingsScene;
    public string leaderboardScene;
    public string mainMenuScene;

    // Method to load the start game scene
    public void StartGame()
    {
        SceneManager.LoadScene(startGameScene);
    }

    // Method to load the settings scene
    public void LoadSettings()
    {
        SceneManager.LoadScene(settingsScene);
    }

    // Method to load the leaderboard scene
    public void LoadLeaderboard()
    {
        SceneManager.LoadScene(leaderboardScene);
    }

    // Method to load the main menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    // Method to quit the game
    public void QuitGame()
    {
        // If running in the Unity editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running in a standalone build
        Application.Quit();
#endif
    }
}
