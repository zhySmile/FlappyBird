using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingPanel : BaseUI
{
    private void OnEnable()
    {
        _replayButton.onClick.AddListener(OnReplayButtonClick);
    }

    private void OnDisable()
    {
        _replayButton.onClick.RemoveListener(OnReplayButtonClick);
    }

    private void OnReplayButtonClick()
    {
        UIManager.Instance.Show(UIType.PlayingPanel);
        UIManager.Instance.Hide(UIType.EndingPanel);
        StateControl.SetState(StateType.Ready);
    }

    [SerializeField]
    private Button _replayButton;
}
