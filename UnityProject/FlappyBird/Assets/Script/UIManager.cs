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
            Load(GetPath(type.ToString()));
        }
    }

    public void Load(string path)
    {
        Debug.Log(path);
        Object obj = Resources.Load(path, typeof(GameObject));
        GameObject panel = GameObject.Instantiate(obj) as GameObject;
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

    private Dictionary<UIType, BaseUI> _typeToUIPanel = new Dictionary<UIType, BaseUI>();
    private static UIManager _instance;
}
