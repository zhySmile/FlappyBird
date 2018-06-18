using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
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
    }

    public int GetScore()
    {
        return _score;
    }

    private int _score;
    private static ScoreManager _instance;
}
