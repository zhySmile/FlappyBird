using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public void PlayDie()
    {
        _audio.PlayOneShot(_die);
    }

    public void PlayHit()
    {
        _audio.PlayOneShot(_hit);
    }

    public void PlayWing()
    {
        Debug.Log("playwing");
        _audio.PlayOneShot(_wing);
    }

    public void PlayPoint()
    {
        _audio.PlayOneShot(_point);
    }

    public void PlaySwooshing()
    {
        _audio.PlayOneShot(_swooshing);
    }

    private void Awake()
    {
        _instance = this;
    }

    private void OnEnable()
    {
        _audio = this.GetComponent<AudioSource>();
    }
    [SerializeField]
    private AudioClip _die;
    [SerializeField]
    private AudioClip _hit;
    [SerializeField]
    private AudioClip _point;
    [SerializeField]
    private AudioClip _swooshing;
    [SerializeField]
    private AudioClip _wing;

    private AudioSource _audio;
    private static AudioManager _instance;
}
