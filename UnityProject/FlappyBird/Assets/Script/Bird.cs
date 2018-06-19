using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private void OnEnable()
    {
        BirdManager.Instance.OnBirdDie += OnBirdDie;
    }

    private void OnDisable()
    {
        BirdManager.Instance.OnBirdDie -= OnBirdDie;
    }

    private void OnBirdDie()
    {
        Debug.Log("onbirddie");
        _isFlyUp = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isFlyUp = true;
            _speed = _upSpeed;
            AudioManager.Instance.PlayWing();
        }

        if (!_isFlyUp)
        {
            _speed += _dropSpeed * Time.deltaTime;
            this.GetComponent<RectTransform>().localPosition += new Vector3(0, -_speed, 0);
        }


        if (_isFlyUp)
        {
            _speed -= _upSpeed * Time.deltaTime;
            this.GetComponent<RectTransform>().localPosition += new Vector3(0, _speed, 0);
            _isFlyUp = _speed <= 0 ? false : true;
        }
    }

    [SerializeField]
    private float _distance;
    [SerializeField]
    private float _time;
    [SerializeField]
    private float _dropSpeed;
    [SerializeField]
    private float _upSpeed;
    private bool _isFlyUp = false;

    private float _speed;
}
