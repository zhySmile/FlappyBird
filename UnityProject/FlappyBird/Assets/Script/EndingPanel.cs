using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingPanel : BaseUI
{
    private void RefreshScore(int score, bool isBestScore)
    {
        for (int i = 0; i < score.ToString().Length; i++)
        {
            int num = int.Parse(score.ToString().Substring(i, 1));
            Score scoreObj = GameObject.Instantiate(_scoreObj.gameObject).GetComponent<Score>();
            if (!isBestScore)
            {
                scoreObj.gameObject.transform.SetParent(_scoreParent);
                scoreObj.GetComponent<RectTransform>().localScale = Vector3.one;
                _scoreObjs.Add(scoreObj);
            }
            else
            {
                scoreObj.gameObject.transform.SetParent(_bestScoreParent);
                scoreObj.GetComponent<RectTransform>().localScale = Vector3.one;
                _bestScoreObjs.Add(scoreObj);
            }
            scoreObj.SetScore(num);
        }
    }

    private void OnEnable()
    {
        _replayButton.onClick.AddListener(OnReplayButtonClick);
        _scoreObjs = new List<Score>();
        _bestScoreObjs = new List<Score>();
        RefreshScore(ScoreManager.Instance.GetScore(), false);
        RefreshScore(ScoreManager.Instance.GetBestScore(), true);
        _newScoreObj.SetActive(ScoreManager.Instance.IsNewBestScore);
    }

    private void OnDisable()
    {
        _replayButton.onClick.RemoveListener(OnReplayButtonClick);
        DestroyScore();
    }

    private void DestroyScore()
    {
        for (int i = 0; i < _scoreObjs.Count; i++)
        {
            Destroy(_scoreObjs[i].gameObject);
        }
        for (int i = 0; i < _bestScoreObjs.Count; i++)
        {
            Destroy(_bestScoreObjs[i].gameObject);
        }
    }

    private void OnReplayButtonClick()
    {
        UIManager.Instance.Show(UIType.PlayingPanel);
        UIManager.Instance.Hide(UIType.EndingPanel);
        StateControl.SetState(StateType.Ready);
    }

    [SerializeField]
    private Button _replayButton;
    [SerializeField]
    private Score _scoreObj;
    [SerializeField]
    private Transform _scoreParent;
    [SerializeField]
    private Transform _bestScoreParent;
    [SerializeField]
    private GameObject _newScoreObj;

    private List<Score> _scoreObjs;
    private List<Score> _bestScoreObjs;
}
