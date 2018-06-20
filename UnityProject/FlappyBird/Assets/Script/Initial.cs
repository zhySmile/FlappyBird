using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initial : MonoBehaviour {

    private void Awake()
    {
        UIManager.Instance.Show(UIType.StartPanel);
    }
}
