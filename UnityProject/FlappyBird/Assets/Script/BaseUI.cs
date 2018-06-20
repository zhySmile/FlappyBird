using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    public UIType UIType;
    public virtual void SetType(UIType type)
    {
        UIType = type;
    }

    public string GetPath()
    {
        return string.Format("{0}{1}", "Prefabs/", UIType.ToString());
    }
}
