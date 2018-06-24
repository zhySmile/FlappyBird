using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BG : MonoBehaviour
{
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
            ResetBG();
        }
    }

    private void ResetBG()
    {
        int randomBG = Random.Range(0, _bgSprites.Count);
        this.GetComponent<Image>().sprite = _bgSprites[randomBG];
    }

    [SerializeField]
    private List<Sprite> _bgSprites;
}


