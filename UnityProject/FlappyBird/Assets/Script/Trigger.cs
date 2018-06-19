using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (BirdManager.Instance.IsBirdDie)
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
        BirdManager.Instance.BirdDie();
    }

    [SerializeField]
    public TriggerType _triggerType;
}

