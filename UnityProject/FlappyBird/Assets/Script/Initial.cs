using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initial : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.Show(UIType.StartPanel);
    }

    private void OnEnable()
    {
        StateControl.OnStateChange += OnStateChange;
    }

    private void OnDisable()
    {
        StateControl.OnStateChange -= OnStateChange;
    }

    private void OnStateChange(StateType type)
    {
        if (type == StateType.Ready)
        {
            BirdManager.Instance.Reset();
            ScoreManager.Instance.Reset();
            ScoreManager.Instance.SetCurrentScore();
        }
        else if (type == StateType.GameOver)
        {
            ScoreManager.Instance.SetCurrentScore();
        }
    }
}
