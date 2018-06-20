using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BaseUI
{
    public override void SetType(UIType type)
    {
        base.SetType(type);
    }

    private void Awake()
    {
        SetType(UIType.StartPanel);
    }

    private void StartGame()
    {
        UIManager.Instance.Show(UIType.PlayingPanel);
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
