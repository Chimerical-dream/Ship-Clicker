using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyView : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    int textValue = int.MinValue;

    private void Start()
    {
        EnergyManager.OnEnergyValueChanged.AddListener(SetEnergyValue);
        SetEnergyValue(EnergyManager.EnergyAmount);
    }

    private void SetEnergyValue(float value)
    {
        int intValue = (int)value;
        if(intValue == textValue)
        {
            return;
        }
        textValue = intValue;
        text.text = textValue.ToString();
    }
}
