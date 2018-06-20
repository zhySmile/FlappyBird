using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPanel : BaseUI
{
    public override void SetType(UIType type)
    {
        base.SetType(type);
    }

    private void Awake()
    {
        SetType(UIType.EndingPanel);
    }
}
