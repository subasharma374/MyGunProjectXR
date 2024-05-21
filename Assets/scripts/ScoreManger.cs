using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [System.Serializable]
    public class ScoreEntry
    {
        public string playerName;
        public int score;
    }

    public List<ScoreEntry> scoreEntries = new List<ScoreEntry>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist this object across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScoreEntry(string playerName, int score)
    {
        scoreEntries.Add(new ScoreEntry { playerName = playerName, score = score });
    }

    public void RemoveScoreEntry(string playerName)
    {
        scoreEntries.RemoveAll(entry => entry.playerName == playerName);
    }

    public void UpdateScoreEntry(string playerName, int newScore)
    {
        foreach (var entry in scoreEntries)
        {
            if (entry.playerName == playerName)
            {
                entry.score = newScore;
                break;
            }
        }
    }

    public void ClearScoreboard()
    {
        scoreEntries.Clear();
    }
}
