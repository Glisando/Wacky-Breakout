using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupBlock : Block
{
    // Start is called before the first frame update
    void Start()
    {
        scorePoints = ConfigurationUtils.SpeedupBlockScorePoints;
        _blockType = BlockType.Speedup;

    }
}
