using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private void Awake()
    {
        Vector3 position = this.GetComponent<RectTransform>().localPosition;
        _birdInitPosition = position;
    }

    private void OnEnable()
    {
        BirdManager.Instance.OnBirdDie += OnBirdDie;
        StateControl.OnStateChange += OnStateChange;
    }

    private void OnDisable()
    {
        BirdManager.Instance.OnBirdDie -= OnBirdDie;
        StateControl.OnStateChange -= OnStateChange;
    }

    private void OnBirdDie()
    {
        _isFlyUp = false;
    }

    private void OnStateChange(StateType state)
    {
        if (state == StateType.Playing)
        {
            StartFlyUp();
        }
        else if (state == StateType.Ready)
        {
            ResetBird();
        }
    }

    private void ResetBird()
    {
        _isFlyUp = false;
        this.GetComponent<RectTransform>().localPosition = _birdInitPosition;
    }

    private void StartFlyUp()
    {
        _isFlyUp = true;
        _speed = _upSpeed;
        AudioManager.Instance.PlayWing();
    }

    void Update()
    {
        if ((StateControl.GetState() != StateType.Playing &&
            StateControl.GetState() != StateType.BirdDie) || BirdManager.Instance.IsBirdGround)
        {
            return;
        }
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
    private Vector3 _birdInitPosition;
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
