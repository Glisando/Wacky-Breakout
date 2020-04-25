using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupPickup : PickupBlock
{
    public static event Action OnSpeedupPickup;

    // Start is called before the first frame update
    void Start()
    {
        _type = PickupType.Speedup;
        base.Start();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnSpeedupPickup();
        AudioManager.Play(AudioClipName.Speedup);
        Destroy(gameObject);
    }
}
