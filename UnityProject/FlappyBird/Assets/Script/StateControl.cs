using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StateControl
{
    public static Action<StateType> OnStateChange = delegate { };

    public static void SetState(StateType state)
    {
        Debug.Log("state   " + state);
        _state = state;
        OnStateChange(state);
    }

    public static StateType GetState()
    {
        return _state;
    }

    private static StateType _state;
}
