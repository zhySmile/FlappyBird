using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isBirdDie)
        {
            return;
        }
        if (_triggerType == TriggerType.AddScore)
        {
            AddScore();
        }
        else if (_triggerType == TriggerType.Die)
        {
            Die();
        }
    }

    private void AddScore()
    {
        ScoreManager.Instance.AddScore();
    }

    private void Die()
    {
        Debug.Log("die");
        _isBirdDie = true;
        BirdManager.Instance.OnBirdDie();
        AudioManager.Instance.PlayHit();
        AudioManager.Instance.PlayDie();
    }

    [SerializeField]
    public TriggerType _triggerType;

    private bool _isBirdDie = false;
}

