using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingsManager
{
    public static GameSettings GameSettings => gameSettings;
    private static GameSettings gameSettings;
    
    public static void Init()
    {
        gameSettings = (GameSettings)Resources.Load("GameSettings", typeof(GameSettings));
    }
}
