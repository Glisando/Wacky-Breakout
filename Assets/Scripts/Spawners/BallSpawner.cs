using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] GameObject _ball;
    Timer _cooldownTimer;
    Transform _transform;

    Vector2 _spawnLocationMin;
    Vector2 _spawnLocationMax;

    bool _retrySpawn = false;
    float _ballsLeft;
    float _minSpawnTime;
    float _maxSpawnTime;

    #endregion

    #region Methods

    void Start()
    {
        _transform = transform;
        _ballsLeft = ConfigurationUtils.BallsNumber;

        _minSpawnTime = ConfigurationUtils.MinBallSpawnTime;
        _maxSpawnTime = ConfigurationUtils.MaxBallSpawnTime;

        _cooldownTimer = gameObject.AddComponent<Timer>();

        // start listening event to spawn new ball 
        Ball.OnDeath += OnBallDeath;

        SetSpawnCorners();

        SpawnBall();
        RunNewTimer();
    }

    void Update()
    {
        if (_retrySpawn)
        {
            SpawnBall();
        }
        if (_cooldownTimer.Finished)
        {
            SpawnBall();
            RunNewTimer();
        }
    }

    void SpawnBall()
    {
        if (_ballsLeft > 0)
        {
            Collider2D target = Physics2D.OverlapArea(_spawnLocationMin, _spawnLocationMax);

            // make sure we don't spawn into a collision
            if (target.TryGetComponent<Background>(out Background bg))
            {
                GameObject tmp = Instantiate(_ball, Vector3.zero, Quaternion.identity);

                tmp.transform.parent = _transform;
                _retrySpawn = false;
            }
            else
            {
                _retrySpawn = true;
            }
        }
    }

    #region Utils Methods

    void OnBallDeath()
    {
        _ballsLeft--;
        Debug.Log(_ballsLeft);
        SpawnBall();
    }

    void RunNewTimer()
    {
        _cooldownTimer.Duration = Random.Range(_minSpawnTime, _maxSpawnTime);
        _cooldownTimer.Run();
    }

    void SetSpawnCorners()
    {
        GameObject tempBall = Instantiate(_ball, Vector3.zero, Quaternion.identity);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        _spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        _spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);
    }

    private void OnDisable()
    {
        Ball.OnDeath -= OnBallDeath;
    }

    #endregion

    #endregion
}
