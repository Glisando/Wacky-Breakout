using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezerPickup : PickupBlock
{
    public static event Action OnFreezerPickup;

    // Start is called before the first frame update
    void Start()
    {
        _type = PickupType.Freezer;
        base.Start();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnFreezerPickup();
        Destroy(gameObject);
    }
}
