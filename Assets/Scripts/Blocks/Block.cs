using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public enum BlockType
    {
        Standard,
        Bonus,
        Freezer,
        Speedup
    };

    public static Action<int> OnBlockDeath;

    [SerializeField] protected GameObject _pickup;

    protected int scorePoints = 0;
    protected BlockType _blockType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball;

        if (collision.gameObject.TryGetComponent<Ball>(out ball))
        {
            AudioManager.Play(AudioClipName.BlockHit);

            OnBlockDeath(scorePoints);

            if (_blockType != BlockType.Standard && _blockType != BlockType.Bonus)
            {
                Instantiate(_pickup, transform.position, Quaternion.identity);
            }

            LevelBuilder.RemoveBlock(gameObject);
        }
    }
}
