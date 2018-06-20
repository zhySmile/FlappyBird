using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    public void Show(UIType type)
    {
        if (_typeToUIPanel.ContainsKey(type))
        {
            _typeToUIPanel[type].gameObject.SetActive(true);
        }
        else
        {
            Load(type, GetPath(type.ToString()));
        }
    }

    public void Hide(UIType type)
    {
        if (_typeToUIPanel.ContainsKey(type))
        {
            _typeToUIPanel[type].gameObject.SetActive(false);
        }
    }

    public void Load(UIType type, string path)
    {
        Debug.Log(path);
        Object obj = Resources.Load(path, typeof(GameObject));
        GameObject panel = GameObject.Instantiate(obj) as GameObject;
        _typeToUIPanel.Add(type, panel);
    }

    public void Show<T>(T item) where T : BaseUI
    {
        if (_typeToUIPanel.ContainsKey(item.UIType))
        {
            _typeToUIPanel[item.UIType].gameObject.SetActive(true);
        }
        else
        {
            Load(item);
        }
    }

    public void Hide<T>(T item) where T : BaseUI
    {
        if (_typeToUIPanel.ContainsKey(item.UIType))
        {
            _typeToUIPanel[item.UIType].gameObject.SetActive(false);
        }
    }

    private void Load<T>(T item) where T : BaseUI
    {
        Object obj = Resources.Load(item.GetPath(), typeof(GameObject));
        GameObject panel = GameObject.Instantiate(obj) as GameObject;
    }

    private string GetPath(string name)
    {
        return string.Format("{0}{1}", "Prefabs/", name);
    }

    private Dictionary<UIType, GameObject> _typeToUIPanel = new Dictionary<UIType, GameObject>();
    private static UIManager _instance;
}
