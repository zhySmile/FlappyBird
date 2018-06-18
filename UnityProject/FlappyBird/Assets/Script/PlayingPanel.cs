using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingPanel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        _scoreobjs = new List<Score>();
        ScoreManager.Instance.OnScoreChange += OnScoreChange;
    }

    private void OnDisable()
    {
        ScoreManager.Instance.OnScoreChange -= OnScoreChange;
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
    private Score _scoreObj;
    [SerializeField]
    private Transform _scoreParent;

    private List<Score> _scoreobjs;
}
