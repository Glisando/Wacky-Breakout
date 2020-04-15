using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
    static float minBallSpawnTime = 5f;
    static float maxBallSpawnTime = 10f;
    static float ballsNumber = 10f;

    static float standardBlockSpawnChance = 0.7f;
    static float bonusBlockSpawnChance = 0.2f;
    static float freezerBlockSpawnChance = 0.05f;
    static float speedupBlockSpawnChance = 0.05f;

    static int standardBlockScorePoints = 1;
    static int bonusBlockScorePoints = 2;
    static int freezerBlockScorePoints = 5;
    static int speedupBlockScorePoints = 5;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }
    }

    public float MinBallSpawnTime
    {
        get { return minBallSpawnTime; }
    }

    public float MaxBallSpawnTime
    {
        get { return maxBallSpawnTime; }
    }

    public float BallsNumber
    {
        get { return ballsNumber; }
    }

    public float StandardBlockSpawnChance
    {
        get {return standardBlockSpawnChance; }
    }

    public float BonusBlockSpawnChance
    {
        get { return bonusBlockSpawnChance; }
    }

    public float FreezerBlockSpawnChance
    {
        get { return freezerBlockSpawnChance; }
    }

    public float SpeedupBlockSpawnChance
    {
        get { return speedupBlockSpawnChance; }
    }

    public int StandardBlockScorePoints
    {
        get { return standardBlockScorePoints; }
    }

    public int BonusBlockScorePoints
    {
        get { return bonusBlockScorePoints; }
    }

    public int FreezerBlockScorePoints
    {
        get { return freezerBlockScorePoints; }
    }

    public int SpeedupBlockScorePoints
    {
        get { return speedupBlockScorePoints; }
    }
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;

        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            string names = input.ReadLine();
            string values = input.ReadLine();

            // Skipping empty lines between names and values
            input.ReadLine();

            while (!input.EndOfStream)
            {
                names += input.ReadLine();
                values += input.ReadLine();

                // Skipping empty lines between names and values
                input.ReadLine();
            }

            SetConfigurationData(names, values);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if (input != null)
                input.Close();
        }

    }

    private void SetConfigurationData(string names, string values)
    {
        Dictionary<string, float> keyValue =  new Dictionary<string, float>();

        string[] arrayNames = names.Split(',');
        string[] arrayValues = values.Split(',');

        if (arrayNames.Length != arrayValues.Length)
        {
            throw new Exception("Missing some Configuration Data");
        }

        for (int i = 0; i < arrayNames.Length; i++)
        {
            keyValue.Add(arrayNames[i], float.Parse(arrayValues[i]));
        }

        paddleMoveUnitsPerSecond = keyValue["paddleMoveUnitsPerSecond"];
        ballImpulseForce = keyValue["ballImpulseForce"];
        minBallSpawnTime = keyValue["minBallSpawnTime"];
        maxBallSpawnTime = keyValue["maxBallSpawnTime"];
        ballsNumber = keyValue["ballsNumber"];

        standardBlockSpawnChance = keyValue["standardBlockSpawnChance"];
        bonusBlockSpawnChance = keyValue["bonusBlockSpawnChance"];
        freezerBlockSpawnChance = keyValue["freezerBlockSpawnChance"];
        speedupBlockSpawnChance = keyValue["speedupBlockSpawnChance"];

        standardBlockScorePoints = (int)keyValue["standardBlockScorePoints"];
        bonusBlockScorePoints = (int)keyValue["bonusBlockScorePoints"];
        freezerBlockScorePoints = (int)keyValue["freezerBlockScorePoints"];
        speedupBlockScorePoints = (int)keyValue["speedupBlockScorePoints"];
    }

    #endregion
}
