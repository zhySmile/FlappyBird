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
        DestroyScore();
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
        _readyButton.enabled = true;
        _tutorialPanel.SetActive(true);
        CreateScore(0);
        DoFade(true, 0);
    }

    private void OnReadyClick()
    {
        _readyButton.enabled = false;
        StateControl.SetState(StateType.Playing);
        DoFade(false, _uiAnimationFadeTime);
    }

    private void OnScoreChange()
    {
        int score = ScoreManager.Instance.GetScore();
        for (int i = 0; i < score.ToString().Length; i++)
        {
            int num = int.Parse(score.ToString().Substring(i, 1));
            if (_scoreobjs.Count <= i)
            {
                CreateScore(num);
            }
            else
            {
                _scoreobjs[i].SetScore(num);
            }
        }
    }

    private void CreateScore(int num)
    {
        Score scoreObj = GameObject.Instantiate(_scoreObj.gameObject).GetComponent<Score>();
        scoreObj.gameObject.transform.SetParent(_scoreParent);
        _scoreobjs.Add(scoreObj);
        scoreObj.SetScore(num);
    }

    private void DestroyScore()
    {
        for (int i = 0; i < _scoreobjs.Count; i++)
        {
            Destroy(_scoreobjs[i].gameObject);
        }
    }
    public void DoFade(bool isShow, float time = 1)
    {
        StartCoroutine(DoFadeAnimation(isShow, time));
    }

    IEnumerator DoFadeAnimation(bool isShow, float time)
    {
        float _time = time;
        float offsetTime = 0.02f;
        float offset = _time == 0 ? 1 : offsetTime / _time;
        if (isShow)
        {
            while (_canvasGroup.alpha < 1)
            {
                yield return new WaitForSeconds(offsetTime);
                _canvasGroup.alpha += offset;
            }
        }
        else
        {
            while (_canvasGroup.alpha > 0)
            {
                yield return new WaitForSeconds(offsetTime);
                _canvasGroup.alpha -= offset;
            }
        }
    }

    [SerializeField]
    private float _uiAnimationFadeTime;
    [SerializeField]
    private Button _readyButton;
    [SerializeField]
    private GameObject _tutorialPanel;
    [SerializeField]
    private Score _scoreObj;
    [SerializeField]
    private Transform _scoreParent;
    [SerializeField]
    private CanvasGroup _canvasGroup;

    private List<Score> _scoreobjs;
}
