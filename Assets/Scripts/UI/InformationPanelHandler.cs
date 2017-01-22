using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanelHandler : MonoBehaviour
{
    public Text NoiseValue_Text;
    public Text RadioactiveValue;
    void Start()
    {
        SetupEvents();
        SetupTexts();
    }

    private void SetupTexts()
    {
        RadioactiveValue.text = string.Format("Nukular: {0}", 0);
        NoiseValue_Text.text = string.Format("Noise : {0}", 0);

    }

    private void SetupEvents()
    {
        IngameUIEventhandler.OnMovementChange += IngameUIEventhandler_OnMovementChange;
        IngameUIEventhandler.OnRadioactiveChange += IngameUIEventhandler_OnRadioactiveChange;
    }

    private void IngameUIEventhandler_OnRadioactiveChange(float value)
    {
        RadioactiveValue.text = string.Format("Nukular: {0}", value.ToString());
    }

    private void IngameUIEventhandler_OnMovementChange(float value)
    {
        NoiseValue_Text.text = string.Format("Noise: {0}", value.ToString());
    }
}
