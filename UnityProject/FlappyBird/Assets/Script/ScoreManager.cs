using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    public bool IsNewBestScore = false;
    public Action OnScoreChange = delegate { };
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ScoreManager();
            }
            return _instance;
        }
    }

    public void Reset()
    {
        _score = 0;
    }

    public void AddScore()
    {
        _score++;
        OnScoreChange();
        AudioManager.Instance.PlayPoint();
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetCurrentScore()
    {
        IsNewBestScore = _score > GetBestScore();
        if (_score > GetBestScore())
        {
            PlayerPrefs.SetInt(_bestScore, _score);
        }
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt(_bestScore, 0);
    }

    private int _score;
    private static ScoreManager _instance;

    private string _bestScore = "bestScore";
}
