using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardManger : MonoBehaviour
{
    public GameObject scoreboardEntryTemplate;
    public Transform content;

    void Start()
    {
        PopulateScoreboard();
    }

    public void PopulateScoreboard()
    {
        // Clear existing entries
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        // Populate the scoreboard from ScoreManager
        foreach (var scoreEntry in ScoreManager.Instance.scoreEntries)
        {
            GameObject newEntry = Instantiate(scoreboardEntryTemplate, content);
            newEntry.transform.Find("PlayerNameText").GetComponent<Text>().text = scoreEntry.playerName;
            newEntry.transform.Find("ScoreText").GetComponent<Text>().text = scoreEntry.score.ToString();
            newEntry.SetActive(true);
        }
    }
}
