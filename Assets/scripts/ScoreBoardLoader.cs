using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardLoader : MonoBehaviour
{

    [System.Serializable]
    public class ScoreEntry
    {
        public string playerName;
        public int score;
    }

    public List<ScoreEntry> scoreEntries;
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

        // Populate the scoreboard
        foreach (var scoreEntry in scoreEntries)
        {
            GameObject newEntry = Instantiate(scoreboardEntryTemplate, content);
            newEntry.transform.Find("PlayerNameText").GetComponent<Text>().text = scoreEntry.playerName;
            newEntry.transform.Find("ScoreText").GetComponent<Text>().text = scoreEntry.score.ToString();
            newEntry.SetActive(true);
        }
    }
}