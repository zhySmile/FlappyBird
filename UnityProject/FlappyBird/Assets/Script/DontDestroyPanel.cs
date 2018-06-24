using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyPanel : MonoBehaviour
{
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
        if (type == StateType.Start)
        {
            _gameBird.gameObject.SetActive(false);
        }
        else if (type == StateType.Ready)
        {
            _gameBird.gameObject.SetActive(true);
        }
    }

    [SerializeField]
    private Bird _gameBird;
}
