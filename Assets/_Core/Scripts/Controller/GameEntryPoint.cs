using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    private void Awake()
    {
        SettingsManager.Init();
        CashManager.Init();
        
        new GameObject("EnergyManager", typeof(EnergyManager));
        new GameObject("PassiveIncomeSystem", typeof(PassiveIncomeSystem));
    }
}
