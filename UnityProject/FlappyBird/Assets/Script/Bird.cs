using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
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
