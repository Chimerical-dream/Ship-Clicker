using Game.Core;
using UnityEngine;
using UnityEngine.Events;

public class EnergyManager : MonoBehaviour
{
    public static UnityEvent<float> OnEnergyValueChanged = new UnityEvent<float>();
    public static float EnergyAmount => instance.energyAmount;

    private static EnergyManager instance;

    private float energyAmount;

    private void Awake()
    {
        instance = this;
        energyAmount = SaveSystem.Instance.Data.EnergyAmount;

        FishButton.OnFishButtonClick.AddListener(OnFishButtonClick);
    }

    private void FixedUpdate()
    {
        if(energyAmount >= SettingsManager.GameSettings.TotalEnergy)
        {
            return;
        }

        SetEnergyAmount(Mathf.Min(energyAmount + SettingsManager.GameSettings.EnergyRestoringSpeed * Time.deltaTime, SettingsManager.GameSettings.TotalEnergy));
    }


    private void OnFishButtonClick()
    {
        SetEnergyAmount(energyAmount - SettingsManager.GameSettings.EnergyPerClick);
    }

    private void SetEnergyAmount(float value)
    {
        energyAmount = value;
        SaveSystem.Instance.Data.EnergyAmount = value;
        OnEnergyValueChanged.Invoke(value);
    }
}
