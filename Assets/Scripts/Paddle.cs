using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Paddle : MonoBehaviour
{
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    private Rigidbody2D _rb2d;
    private BoxCollider2D _box2d;
    private Timer _pauseTimer;

    private float _vx = 0f;
    private float _speed;
    private float _screenBorder;
    private float _halfColliderWidth;
    private float _topEdge;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _box2d = GetComponent<BoxCollider2D>();

        _speed = ConfigurationUtils.PaddleMoveUnitsPerSecond;

        _halfColliderWidth = _box2d.size.x / 2;
        _screenBorder = ScreenUtils.ScreenRight - _halfColliderWidth;
        _topEdge = transform.position.y + _box2d.size.y / 2.5f;

        FreezerPickup.OnFreezerPickup += FreezerPickupHandler;
        SpeedupPickup.OnSpeedupPickup += SpeedupPickupHandler;
        _pauseTimer = gameObject.AddComponent<Timer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_pauseTimer.Running)
        {
            _vx = Input.GetAxis("Horizontal");

            if (_vx != 0)
            {
                float speedThisFrame = _vx * _speed * Time.fixedDeltaTime;
                float newXPosition = CheckBorders(speedThisFrame + transform.position.x);

                _rb2d.MovePosition(new Vector2(newXPosition, transform.position.y));
            }
        }
    }

    private float CheckBorders(float v)
    {
        if (v < 0)
        {
            return v < -_screenBorder ? -_screenBorder : v;
        }
        else
        {
            return v > _screenBorder ? _screenBorder : v;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Ball ballScript;

        if (coll.gameObject.TryGetComponent<Ball>(out ballScript))
        {
            if (coll.GetContact(0).point.y >= _topEdge)
            {
                // calculate new ball direction
                float ballOffsetFromPaddleCenter = transform.position.x -
                    coll.transform.position.x;
                float normalizedBallOffset = ballOffsetFromPaddleCenter /
                    _halfColliderWidth;
                float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
                float angle = Mathf.PI / 2 + angleOffset;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                ballScript.SetDirection(direction);
            }
        }
    }

    void FreezerPickupHandler()
    {
        _pauseTimer.Duration = ConfigurationUtils.FreezTime;
        _pauseTimer.Run();
    }

    void SpeedupPickupHandler() { }

    private void OnDestroy()
    {
        FreezerPickup.OnFreezerPickup -= FreezerPickupHandler;
        SpeedupPickup.OnSpeedupPickup -= SpeedupPickupHandler;
    }
}
