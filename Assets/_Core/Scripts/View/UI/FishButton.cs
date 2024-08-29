using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FishButton : Button
{
    public static UnityEvent OnFishButtonClick = new UnityEvent();

    [SerializeField]
    private float clickCooldown = .15f;
    private float lastClickTimeStamp = 0;

    public override void OnPointerClick(PointerEventData eventData)
    {
        if(EnergyManager.EnergyAmount < SettingsManager.GameSettings.EnergyRestoringSpeed)
        {
            return;
        }

        float time = Time.realtimeSinceStartup;
        if(time - lastClickTimeStamp < clickCooldown)
        {
            return;
        }
        lastClickTimeStamp = time;

        CashManager.AddCash(SettingsManager.GameSettings.CashPerClick + SettingsManager.GameSettings.PassiveIncomePercentPerClick * SettingsManager.GameSettings.PassiveIncomeAmount);
        OnFishButtonClick.Invoke();
        
        base.OnPointerClick(eventData);
    }
}
