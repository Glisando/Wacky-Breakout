using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Fields

    public static Action OnDeath;

    enum States
    {
        Start,
        Moving,
        Idle,
        Death
    };

    Timer _startDelayTimer;
    Timer _deathTimer;
    Dictionary<States, System.Action> _states;

    States _currentState;

    const float AngleHalfRange = 180 * Mathf.Deg2Rad;
    private Rigidbody2D _rb2d;
    private BoxCollider2D _box2d;
    private Transform _transform;

    #endregion

    #region Methods

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _box2d = GetComponent<BoxCollider2D>();
        _transform = transform;

        CreateStatesDictionary();

        _startDelayTimer = gameObject.AddComponent<Timer>();
        _startDelayTimer.Duration = 1f;
        _startDelayTimer.Run();

        _deathTimer = gameObject.AddComponent<Timer>();
        _deathTimer.Duration = 10f;

        _currentState = States.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        _states[_currentState]();
    }

    #region State Methods

    void IdleState()
    {
        if (_startDelayTimer.Finished)
        {
            _currentState = States.Start;
        }
    }

    void StartState()
    {
        float angle = Mathf.PI / 2 + AngleHalfRange;

        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        _rb2d.AddForce(direction * ConfigurationUtils.BallImpulseForce);

        _deathTimer.Run();
        _currentState = States.Moving;
    }

    void MovingState()
    {
        if (_deathTimer.Finished)
        {
            _currentState = States.Death;
        }
        ClampByMaxVelocity();
    }

    void DeathState()
    {
        if (!_deathTimer.Finished)
        {
            OnDeath();
        }
        Destroy(gameObject);
    }

    #endregion

    #region Utils Methods

    private void OnTriggerExit2D(Collider2D collision)
    {
        _currentState = States.Death;
    }

    void CreateStatesDictionary()
    {
        _states = new Dictionary<States, Action>();

        _states.Add(States.Idle, IdleState);
        _states.Add(States.Moving, MovingState);
        _states.Add(States.Start, StartState);
        _states.Add(States.Death, DeathState);
    }

    public void SetDirection(Vector2 direction)
    {
        _rb2d.velocity = direction * _rb2d.velocity.magnitude;
    }

    private void ClampByMaxVelocity()
    {
        if (Mathf.Abs(_rb2d.velocity.x) > 7)
        {
            Vector2 newVelocity = new Vector2(7, 7);

            newVelocity.x = _rb2d.velocity.x > 0 ? 7 : -7;
            newVelocity.y = _rb2d.velocity.y > 0 ? 7 : -7;

            _rb2d.velocity = newVelocity;
        }
    }

    #endregion

    #endregion

}
