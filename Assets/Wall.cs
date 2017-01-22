using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public TightWay Way;

    void OnTriggerEnter(Collider other)
    {
        WaveExpander wave = other.GetComponent<WaveExpander>();
        if (wave)
        {
            Way.StartAlarm();
        }
    }
}
