using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BirdManager.Instance.SetBirdGround();
    }

    void Update()
    {
        if (BirdManager.Instance.IsBirdDie)
        {
            return;
        }
        this.GetComponent<RectTransform>().localPosition += new Vector3(1, 0, 0) * _speed;
        if (this.GetComponent<RectTransform>().localPosition.x <
            -this.GetComponent<RectTransform>().sizeDelta.x)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        this.GetComponent<RectTransform>().localPosition = new Vector3
            (this.gameObject.GetComponent<RectTransform>().localPosition.x
            + 2 * (this.GetComponent<RectTransform>().sizeDelta.x - 3f),
            this.GetComponent<RectTransform>().localPosition.y,
            this.GetComponent<RectTransform>().localPosition.z);
    }

    [SerializeField]
    private float _speed;
    [SerializeField]
    private Ground _ground;

    private Channel _lastChannel;
    private Channel _nextChannel;
}
