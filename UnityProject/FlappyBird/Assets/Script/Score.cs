using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public void SetScore(int score)
    {
        this.GetComponent<Image>().sprite = _nums[score];
    }

    [SerializeField]
    private List<Sprite> _nums;
}
