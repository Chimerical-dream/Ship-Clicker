using Game.Core;
using System.Collections.Generic;

/// <summary>
/// Main class that holds all savable data
/// </summary>
[System.Serializable]
public class SaveData {
    public float CashAmount;
    public float EnergyAmount;
    public string GameVersion;

    public SaveData()
    {
        CashAmount = 0;
        EnergyAmount = SettingsManager.GameSettings == null ? 0 : SettingsManager.GameSettings.TotalEnergy;
    }
}