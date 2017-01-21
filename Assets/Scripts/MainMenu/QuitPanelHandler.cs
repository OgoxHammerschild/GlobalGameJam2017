using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitPanelHandler : MonoBehaviour
{
    float speed = 1;
    public Image MainPanel;

    void Update()
    {
        float t = (Mathf.Sin(Time.time * speed) + 1) / 2;
    }
}
