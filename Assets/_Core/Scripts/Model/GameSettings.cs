using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    [Header("Energy")]
    public float EnergyPerClick = 5;
    public float EnergyRestoringSpeed = 10f;
    public float TotalEnergy = 60;

    [Header("Clicking")]
    public float CashPerClick = 10;
    public float PassiveIncomePercentPerClick = .1f;

    [Header("Passive Income")]
    public float PassiveIncomeAmount = 5;
    public float PassiveIncomeCooldown = 2f;
}
