using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private UIController _uiController;

    private void OnEnable()
    {
        Time.timeScale = 0;
        _scoreText.text = "Score: " + _uiController.Score;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
