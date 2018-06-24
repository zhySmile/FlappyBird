using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        this.GetComponent<RectTransform>().localEulerAngles = Vector3.zero;
        int randomBird = Random.Range(0, _birdImage.Count);
        this.GetComponent<Image>().sprite = _birdImage[randomBird];
        string strPath = "animation/Bird" + randomBird;
        RuntimeAnimatorController runAnim = Resources.Load<RuntimeAnimatorController>(strPath);
        this.GetComponent<Animator>().runtimeAnimatorController = runAnim;
    }

    private void StartFlyUp()
    {
        _isFlyUp = true;
        _speed = vecY;
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
            vecY = _fixedSpeed;
            AudioManager.Instance.PlayWing();
            //_targerPositionY = this.GetComponent<RectTransform>().localPosition.y + _distance;
        }

        if (!_isFlyUp)
        {
            vecY -= _speed * Time.deltaTime;
            transform.position += new Vector3(0, vecY, 0);
            Quaternion initial = this.GetComponent<RectTransform>().localRotation;
            Quaternion target = Quaternion.Euler(_downRotation);
            this.GetComponent<RectTransform>().localRotation = Quaternion.Lerp(initial, target, _rotateSpeed * Time.deltaTime);
        }


        if (_isFlyUp)
        {
            FlyUp();
        }
    }

    private void FlyUp()
    {
        vecY -=  _speed * Time.deltaTime;
        transform.position += new Vector3(0, vecY, 0);
        _isFlyUp = _speed <= 0 ? false : true;

        //Quaternion initial = Quaternion.Euler(Vector3.zero);
        Quaternion initial = this.GetComponent<RectTransform>().localRotation;
        Quaternion target = Quaternion.Euler(_upRotation);
        this.GetComponent<RectTransform>().localRotation = Quaternion.Lerp(initial, target, _rotateSpeed * Time.deltaTime);
    }
    //private void TestFlyUp()
    //{
    //    _speed -= vecY * Time.deltaTime;

    //    this.GetComponent<RectTransform>().localPosition += new Vector3(0, _speed, 0);
    //    _isFlyUp = _speed <= 0 ? false : true;

    //    //Quaternion initial = Quaternion.Euler(Vector3.zero);
    //    Quaternion initial = this.GetComponent<RectTransform>().localRotation;
    //    Quaternion target = Quaternion.Euler(_upRotation);
    //    this.GetComponent<RectTransform>().localRotation = Quaternion.Lerp(initial, target, _rotateSpeed * Time.deltaTime);
    //}

    [SerializeField]
    private List<Sprite> _birdImage;
    [SerializeField]
    private Vector3 _upRotation;
    [SerializeField]
    private Vector3 _downRotation;
    [SerializeField]
    private Vector3 _birdInitPosition;
    [SerializeField]
    private float _distance;
    [SerializeField]
    private float _time;
    [SerializeField]
    private float _dropSpeed;
    [SerializeField]
    private float vecY;
    [SerializeField]
    private float _rotateSpeed;

    private bool _isFlyUp = false;
    [SerializeField]
    private float _speed;
    private float _rotation;

    private float _targerPositionY;


    [SerializeField]
    private float _fixedSpeed;
}
