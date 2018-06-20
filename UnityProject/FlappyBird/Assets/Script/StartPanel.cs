using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BaseUI
{
    private void StartGame()
    {
        UIManager.Instance.Show(UIType.PlayingPanel);
        UIManager.Instance.Hide(UIType.StartPanel);
        StateControl.SetState(StateType.Ready);
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartGame);
    }

    [SerializeField]
    private Button _startButton;
}
