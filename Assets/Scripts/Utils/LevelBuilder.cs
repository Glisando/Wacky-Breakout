using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    enum BlockType
    {
        Standard,
        Bonus,
        Freezer,
        Speedup
    };

    [SerializeField] GameObject _ballSpawner;
    [SerializeField] GameObject _paddle;

    [Header("Blocks Area")]
    [SerializeField] GameObject standardBlock;
    [SerializeField] GameObject bonusBlock;
    [SerializeField] GameObject freezerBlock;
    [SerializeField] GameObject speedupBlock;

    [SerializeField] GameObject parentBlock;

    Transform parentBlockTransform;
    Vector2 _blockSize;
    float _screenWidth;
    float _rowWidth;
    float _blockNum = 15;

    // Start is called before the first frame update
    void Start()
    {
        _blockSize = standardBlock.GetComponent<BoxCollider2D>().size;
        _screenWidth = -ScreenUtils.ScreenLeft + ScreenUtils.ScreenRight;
        _rowWidth = _blockSize.x * _blockNum;
        _blockNum = _rowWidth < _screenWidth ? 15 : 5;

        Instantiate(_paddle, Vector2.down * 4, Quaternion.identity);
        Instantiate(_ballSpawner, Vector2.left * 6, Quaternion.identity);
        parentBlock = Instantiate(parentBlock, Vector2.left * 6, Quaternion.identity);

        parentBlockTransform = parentBlock.transform;

        SpawnBlocks();
    }

    void SpawnBlocks()
    {
        Vector2 startPos = new Vector2(0, 0);

        float offsetX = (_screenWidth - _rowWidth) / 2;

        startPos.x = (_blockSize.x / 2 + ScreenUtils.ScreenLeft) + offsetX;
        startPos.y = ScreenUtils.ScreenTop - (ScreenUtils.ScreenTop / 2f);

        Vector2 currentPos = startPos;
        for (int i = 0; i < 3; i++)
        {
            currentPos.y += _blockSize.y;
            currentPos.x = startPos.x;
            for (int x = 0; x < _blockNum; x++)
            {
                GameObject tmp = Instantiate(ChooseBlockToSpawn(), currentPos, Quaternion.identity);
                tmp.transform.parent = parentBlockTransform;

                currentPos.x += _blockSize.x;
            }
        }
    }

    GameObject ChooseBlockToSpawn()
    {
        float value = Random.value;

        if (value <= ConfigurationUtils.FreezerBlockSpawnChance +
                    ConfigurationUtils.SpeedupBlockSpawnChance)
        {
            return Random.value > 0.5 ?  freezerBlock : speedupBlock;
        }
        else if (value <= ConfigurationUtils.BonusBlockSpawnChance)
        {
            return bonusBlock;
        }
        else
        {
            return standardBlock;
        }
    }
}
