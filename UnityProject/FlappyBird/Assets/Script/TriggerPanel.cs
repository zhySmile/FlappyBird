using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPanel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < _channels.Count; i++)
        {
            if (i == 0)
            {
                _channels[i].SetChannel(_channels[_channels.Count - 1], _channels[i + 1]);
            }
            else if (i == _channels.Count - 1)
            {
                _channels[i].SetChannel(_channels[i - 1], _channels[0]);
            }
            else
            {
                _channels[i].SetChannel(_channels[i - 1], _channels[i + 1]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    [SerializeField]
    private List<Channel> _channels;
}
