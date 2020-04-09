using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    const float AngleHalfRange = 180 * Mathf.Deg2Rad;
    private Rigidbody2D _rb2d;
    private BoxCollider2D _box2d;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _box2d = GetComponent<BoxCollider2D>();

        float angle = Mathf.PI / 2 + AngleHalfRange;

        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        _rb2d.AddForce(direction * ConfigurationUtils.BallImpulseForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        _rb2d.velocity = direction * _rb2d.velocity.magnitude;
    }
}
