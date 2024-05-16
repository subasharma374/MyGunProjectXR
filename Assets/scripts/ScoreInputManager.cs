using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class ScoreInputManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_InputField nameInputField;
    public Button submitButton;

    private int currentScore;

    void Start()
    {
        // Assume currentScore is passed via PlayerPrefs or another method
        //currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        currentScore = 55; //hardcode to test
        scoreText.text = "Score: " + currentScore.ToString();

        submitButton.onClick.AddListener(OnSubmitScore);
    }

    void OnSubmitScore()
    {
        string playerName = nameInputField.text;
        if (!string.IsNullOrEmpty(playerName))
        {
            // Add the score entry to the ScoreManager
            ScoreManager.Instance.AddScoreEntry(playerName, currentScore);
            // Optionally, load the scoreboard scene
            SceneManager.LoadScene("ScoreboardScene");
        }
        else
        {
            // Handle the case where the name input field is empty
            Debug.LogWarning("Player name cannot be empty!");
        }
    }
}
