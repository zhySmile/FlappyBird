using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Channel : MonoBehaviour
{
    public void SetChannel(Channel last, Channel next)
    {
        _lastChannel = last;
        _nextChannel = next;
    }

    void Update()
    {
        this.GetComponent<RectTransform>().localPosition += new Vector3(1, 0, 0) * _speed;
        if (_isActive && this.GetComponent<RectTransform>().localPosition.x < -1640f)
        {
            _isActive = false;
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        this.GetComponent<RectTransform>().localPosition = new Vector3
            (_lastChannel.gameObject.GetComponent<RectTransform>().localPosition.x + _distance,
            this.GetComponent<RectTransform>().localPosition.y,
            this.GetComponent<RectTransform>().localPosition.z);
        SetPositionY();
        _isActive = true;
    }

    private void SetPositionY()
    {
        float y = Random.Range(-370f, 720f);
        this.GetComponent<RectTransform>().localPosition = new Vector3
           (this.GetComponent<RectTransform>().localPosition.x, y,
           this.GetComponent<RectTransform>().localPosition.z);
    }

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _distance;

    private Channel _lastChannel;
    private Channel _nextChannel;

    private bool _isActive = true;
}
