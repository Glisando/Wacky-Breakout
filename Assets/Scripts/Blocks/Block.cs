using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static Action<int> OnBlockDeath;

    protected int scorePoints = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball;

        if (collision.gameObject.TryGetComponent<Ball>(out ball))
        {
            OnBlockDeath(scorePoints);
            Destroy(gameObject);
        }
    }
}
