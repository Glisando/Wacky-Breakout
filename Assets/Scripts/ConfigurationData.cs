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

            SetConfigurationData(names, values);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
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
    }

    #endregion
}
