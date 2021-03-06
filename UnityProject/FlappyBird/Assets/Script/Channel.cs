﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Channel : MonoBehaviour
{
    private void Awake()
    {
        _initPosition = this.GetComponent<RectTransform>().localPosition;
    }

    public void SetChannel(Channel last, Channel next, int index)
    {
        _lastChannel = last;
        _nextChannel = next;
        InitPosition(index);
    }

    void Update()
    {
        if (StateControl.GetState() != StateType.Playing || BirdManager.Instance.IsBirdDie)
        {
            return;
        }
        this.GetComponent<RectTransform>().localPosition += new Vector3(1, 0, 0) * _speed;
        if (this.GetComponent<RectTransform>().localPosition.x < -1900f)
        {
            ResetPosition();
        }
    }

    private void InitPosition(int index)
    {
        if (index != 0)
        {
            this.GetComponent<RectTransform>().localPosition = new Vector3
          (_lastChannel.gameObject.GetComponent<RectTransform>().localPosition.x + _distance,
          this.GetComponent<RectTransform>().localPosition.y,
          this.GetComponent<RectTransform>().localPosition.z);
        }
        SetPositionY();
    }

    private void ResetPosition()
    {
        this.GetComponent<RectTransform>().localPosition = new Vector3
            (_lastChannel.gameObject.GetComponent<RectTransform>().localPosition.x + _distance,
            this.GetComponent<RectTransform>().localPosition.y,
            this.GetComponent<RectTransform>().localPosition.z);
        SetPositionY();
    }

    private void SetPositionY()
    {
        float y = Random.Range(-370f, 720f);
        this.GetComponent<RectTransform>().localPosition = new Vector3
           (this.GetComponent<RectTransform>().localPosition.x, y,
           this.GetComponent<RectTransform>().localPosition.z);
    }

    [SerializeField]
    private Vector3 _initPosition;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _distance;

    private Channel _lastChannel;
    private Channel _nextChannel;
}
