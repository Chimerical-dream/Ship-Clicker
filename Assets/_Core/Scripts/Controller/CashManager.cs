using Game.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class CashManager 
{
    public static UnityEvent<float> OnCashAmountChanged = new UnityEvent<float>();

    public static int Cash => (int)cash;
    private static float cash;


    public static void Init()
    {
        cash = SaveSystem.Instance.Data.CashAmount;
    }

    public static void AddCash(float amount)
    {
        cash += amount;
        SaveSystem.Instance.Data.CashAmount = cash;
        OnCashAmountChanged.Invoke(cash);
    }
}
