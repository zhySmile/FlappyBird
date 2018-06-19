using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BirdManager
{
    public Action OnBirdDie = delegate { };

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



    private static BirdManager _instance;
}
