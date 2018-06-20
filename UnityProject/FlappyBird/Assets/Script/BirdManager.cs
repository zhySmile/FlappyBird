using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BirdManager
{
    public Action OnBirdDie = delegate { };
    public bool IsBirdDie = false;
    public bool IsBirdGround = false;

    public static BirdManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BirdManager();
            }
            return _instance;
        }
    }

    public void Reset()
    {
        _instance = null;
    }

    public void BirdDie()
    {
        AudioManager.Instance.PlayHit();
        AudioManager.Instance.PlayDie();
        OnBirdDie();
        IsBirdDie = true;
    }

    public void SetBirdGround()
    {
        if (!IsBirdDie)
        {
            BirdDie();
        }
        IsBirdGround = true;
        StateControl.SetState(StateType.GameOver);
    }

    private static BirdManager _instance;
}
