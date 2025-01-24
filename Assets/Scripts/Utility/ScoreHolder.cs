using UnityEngine;
using System.IO;
using Zenject;
using System;

public class ScoreHolder 
{
    private int _totalScore;
    public int MaxScore { get; private set; }
    public int TotalScore { get { return _totalScore; } }
    HealthComponent _playersHealth;

    private const string HighScoreFileName = "HighScore.json";

    public Action<int> OnScoreChange;
    public Action<int> OnHighScoreChange;
    public ScoreHolder(HealthComponent playersHealth)
    {
        _playersHealth = playersHealth;
        LoadHighScore();
        _playersHealth.OnDeath += RessetScore;

    }
    ~ScoreHolder()
    {
        _playersHealth.OnDeath -= RessetScore;  
    }
    private void RessetScore()
    {
        _totalScore = 0;
        OnScoreChange?.Invoke(_totalScore);
    }

    public void AddScore(int score)
    {
        _totalScore += score;
        OnScoreChange?.Invoke(_totalScore);
        if (_totalScore > MaxScore)
        {
            MaxScore = _totalScore;
            SaveHighScore();
            OnHighScoreChange?.Invoke(MaxScore);
        }
    }

    private void LoadHighScore()
    {
        string filePath = Path.Combine(Application.dataPath, "Resources", HighScoreFileName);

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            HighScoreData highScoreData = JsonUtility.FromJson<HighScoreData>(json);
            MaxScore = highScoreData.HighScore;
        }
        else
        {
            string resourcesPath = Path.Combine(Application.dataPath, "Resources");
            if (!Directory.Exists(resourcesPath))
            {
                Directory.CreateDirectory(resourcesPath);
            }
            HighScoreData highScoreData = new HighScoreData { HighScore = MaxScore };
            string json = JsonUtility.ToJson(highScoreData, true);
            File.WriteAllText(filePath, json);
            Debug.Log(File.Exists(filePath));
            MaxScore = 0;
        }
    }

    private void SaveHighScore()
    {
        string filePath = Path.Combine(Application.dataPath, "Resources", HighScoreFileName);

        HighScoreData highScoreData = new HighScoreData { HighScore = MaxScore };
        string json = JsonUtility.ToJson(highScoreData, true);

            File.WriteAllText(filePath, json);
        Debug.Log($"High score saved: {MaxScore}");
    }

    [System.Serializable]
    private class HighScoreData
    {
        public int HighScore;
    }
}
