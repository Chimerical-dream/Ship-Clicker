using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveIncomeSystem : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DoPassiveIncome());
    }

    IEnumerator DoPassiveIncome()
    {
        while (true)
        {
            yield return new WaitForSeconds(SettingsManager.GameSettings.PassiveIncomeCooldown);

            CashManager.AddCash(SettingsManager.GameSettings.PassiveIncomeAmount);
        }
    }
}
