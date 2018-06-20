using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPanel : MonoBehaviour
{
    void Start()
    {
        ResetTrigger();
    }

    private void OnEnable()
    {
        StateControl.OnStateChange += OnStateChange;
    }

    private void OnDisable()
    {
        StateControl.OnStateChange -= OnStateChange;
    }

    private void OnStateChange(StateType state)
    {
        if (state == StateType.Ready)
        {
            ResetTrigger();
        }
    }

    private void ResetTrigger()
    {
        Debug.Log("reset");
        for (int i = 0; i < _channels.Count; i++)
        {
            if (i == 0)
            {
                _channels[i].SetChannel(_channels[_channels.Count - 1], _channels[i + 1], i);
            }
            else if (i == _channels.Count - 1)
            {
                _channels[i].SetChannel(_channels[i - 1], _channels[0], i);
            }
            else
            {
                _channels[i].SetChannel(_channels[i - 1], _channels[i + 1], i);
            }
        }
    }

    [SerializeField]
    private List<Channel> _channels;
}
