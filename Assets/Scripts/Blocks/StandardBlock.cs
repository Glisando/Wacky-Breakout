using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    // Start is called before the first frame update
    void Start()
    {
        scorePoints = ConfigurationUtils.StandardBlockScorePoints;
        _blockType = BlockType.Standard;

    }
}
