using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] Text _scoreText;
    [SerializeField] Text _ballsLeftText;
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _winPanel;

    string _scoreTemplate = "Score: ";
    string _ballsLeftTemplate = "Balls left: ";

    float _ballsLeft;
    int _score = 0;

    public int Score
    {
        get { return _score; }
    }

    void Start()
    {
        _ballsLeft = ConfigurationUtils.BallsNumber;
        _ballsLeftText.text = _ballsLeftTemplate + _ballsLeft.ToString();
        _scoreText.text = _scoreTemplate + _score.ToString();

        Ball.OnDeath += DecreaseBallsNumber;
        Block.OnBlockDeath += IncreaseScore;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_gameOverPanel.activeSelf && !_winPanel.activeSelf)
        {
            OnClickPauseButton();
        }

        if (_ballsLeft <= 0)
        {
            _gameOverPanel.SetActive(true);
        }
        else if (LevelBuilder.BlocksLeft <= 0)
        {
            _winPanel.SetActive(true);
        }
    }

    void DecreaseBallsNumber()
    {
        _ballsLeft--;
        _ballsLeftText.text = _ballsLeftTemplate + _ballsLeft;
    }

    void IncreaseScore(int points)
    {
        _score += points;
        _scoreText.text = _scoreTemplate + _score.ToString();
    }

    private void OnDisable()
    {
        Ball.OnDeath -= DecreaseBallsNumber;
        Block.OnBlockDeath -= IncreaseScore;
    }

    public void OnClickPauseButton()
    {
        AudioManager.Play(AudioClipName.Click);

        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }
}
