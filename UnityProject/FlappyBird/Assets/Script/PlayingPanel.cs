using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingPanel : BaseUI
{
    private void OnEnable()
    {
        _scoreobjs = new List<Score>();
        ScoreManager.Instance.OnScoreChange += OnScoreChange;
        _readyButton.onClick.AddListener(OnReadyClick);
        StateControl.OnStateChange += OnStateChange;
    }

    private void OnDisable()
    {
        ScoreManager.Instance.OnScoreChange -= OnScoreChange;
        _readyButton.onClick.RemoveListener(OnReadyClick);
        StateControl.OnStateChange -= OnStateChange;
    }

    private void OnStateChange(StateType state)
    {
        if (state == StateType.GameOver)
        {
            UIManager.Instance.Show(UIType.EndingPanel);
            UIManager.Instance.Hide(UIType.PlayingPanel);
        }
        else if (state == StateType.Ready)
        {
            ResetPanel();
        }
    }

    private void ResetPanel()
    {
        _tutorialPanel.SetActive(true);
    }

    private void OnReadyClick()
    {
        StateControl.SetState(StateType.Playing);
        _tutorialPanel.SetActive(false);
    }

    private void OnScoreChange()
    {
        int score = ScoreManager.Instance.GetScore();
        for (int i = 0; i < score.ToString().Length; i++)
        {
            int num = int.Parse(score.ToString().Substring(i, 1));
            if (_scoreobjs.Count <= i)
            {
                Score scoreObj = GameObject.Instantiate(_scoreObj.gameObject).GetComponent<Score>();
                scoreObj.gameObject.transform.SetParent(_scoreParent);
                scoreObj.SetScore(num);
                _scoreobjs.Add(scoreObj);
            }
            else
            {
                _scoreobjs[i].SetScore(num);
            }
        }
    }

    [SerializeField]
    private Button _readyButton;
    [SerializeField]
    private GameObject _tutorialPanel;
    [SerializeField]
    private Score _scoreObj;
    [SerializeField]
    private Transform _scoreParent;

    private List<Score> _scoreobjs;
}
