using Game.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private AddScoreVisual addScoreText;
    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    int textValue = int.MinValue;

    private void Start()
    {
        CashManager.OnCashAmountChanged.AddListener(SetCashValue);
        FishButton.OnFishButtonClick.AddListener(OnFishButtonClick);
        SetCashValue(CashManager.Cash);
    }

    private void OnFishButtonClick()
    {
        var fx = PoolManager.instance.Reuse(addScoreText);
        fx.transform.parent = transform;
        int amount = (int)(SettingsManager.GameSettings.CashPerClick + SettingsManager.GameSettings.PassiveIncomePercentPerClick * SettingsManager.GameSettings.PassiveIncomeAmount);
        fx.GetComponent<AddScoreVisual>().SetAmountAndStartAnim(amount);
    }

    private void SetCashValue(float value)
    {
        int intValue = (int)value;
        if (intValue == textValue)
        {
            return;
        }
        textValue = intValue;
        text.text = textValue.ToString();
    }
}
