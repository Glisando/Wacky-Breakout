using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData configurationData;
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static float MinBallSpawnTime
    {
        get { return configurationData.MinBallSpawnTime; }
    }

    public static float MaxBallSpawnTime
    {
        get { return configurationData.MaxBallSpawnTime; }
    }

    public static float BallsNumber
    {
        get { return configurationData.BallsNumber; }
    }

    public static float StandardBlockSpawnChance
    {
        get { return configurationData.StandardBlockSpawnChance; }
    }

    public static float BonusBlockSpawnChance
    {
        get { return configurationData.BonusBlockSpawnChance; }
    }

    public static float FreezerBlockSpawnChance
    {
        get { return configurationData.FreezerBlockSpawnChance; }
    }

    public static float SpeedupBlockSpawnChance
    {
        get { return configurationData.SpeedupBlockSpawnChance; }
    }

    public static int StandardBlockScorePoints
    {
        get { return configurationData.StandardBlockScorePoints; }
    }

    public static int BonusBlockScorePoints
    {
        get { return configurationData.BonusBlockScorePoints; }
    }

    public static int FreezerBlockScorePoints
    {
        get { return configurationData.FreezerBlockScorePoints; }
    }

    public static int SpeedupBlockScorePoints
    {
        get { return configurationData.SpeedupBlockScorePoints; }
    }
    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
