using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
        OnStateChange(StateControl.GetState());
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
            if (_idelTween != null)
            {
                _idelTween.Kill();
            }
            StartFlyUp();
        }
        else if (state == StateType.Start || state == StateType.Ready)
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
        _idelTween = this.transform.DOLocalMoveY(_idelUpPositionY, _idelUpDuration);
        _idelTween.SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void StartFlyUp()
    {
        _stepY = _distance + Time.deltaTime * _fixedSpeed;
        AudioManager.Instance.PlayWing();
    }

    void Update()
    {
        if (StateControl.GetState() != StateType.Playing)
        {
            if (BirdManager.Instance.IsBirdGround)
            {
                if (transform.localPosition.y + _stepY < -502f)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, -502f, transform.localPosition.z);
                }
            }
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!BirdManager.Instance.IsBirdDie)
            {
                AudioManager.Instance.PlayWing();
                _stepY = _distance + Time.deltaTime * _fixedSpeed;
            }
        }
        _stepY -= Time.deltaTime * _fixedSpeed;
        transform.localPosition += new Vector3(0, _stepY, 0);

        Quaternion initial = this.GetComponent<RectTransform>().localRotation;
        Quaternion target;
        if (_stepY >= 0)
        {
            target = Quaternion.Euler(_upRotation);
        }
        else
        {
            target = Quaternion.Euler(_downRotation);
        }
        this.GetComponent<RectTransform>().localRotation = Quaternion.Lerp(initial, target, _rotateSpeed * Time.deltaTime);
    }

    [SerializeField]
    private float _idelUpPositionY;
    [SerializeField]
    private float _idelUpDuration;
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

    private float _stepY;

    private float _targerPositionY;
    private Tween _idelTween;


    [SerializeField]
    private float _fixedSpeed;
}
