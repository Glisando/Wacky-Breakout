using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class PickupBlock : MonoBehaviour
{
    public enum PickupType
    {
        Default,
        Freezer,
        Speedup
    };

    private Rigidbody2D _rb2d;

    protected PickupType _type = PickupType.Default;

    protected void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.AddForce(Vector2.down * ConfigurationUtils.PickupBlockImpulseForce);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
