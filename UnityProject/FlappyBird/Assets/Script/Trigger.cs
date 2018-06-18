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
        Debug.Log("addscore");
    }

    private void Die()
    {
        Debug.Log("die");
    }

    [SerializeField]
    public TriggerType _triggerType;
}

