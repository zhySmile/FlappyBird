using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        AudioManager.Instance.PlayHit();
        AudioManager.Instance.PlayDie();
    }

    [SerializeField]
    public TriggerType _triggerType;
}

