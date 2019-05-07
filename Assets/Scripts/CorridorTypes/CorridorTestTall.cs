using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorTestTall : CorridorManager
{
    public override void SetupCorridor(Corridor corridor)
    {
        wallHeight = 2;
        ceilingHeight = 4;

        currentCorridor = corridor;
        currentCorridor.corridorHolder = new GameObject("Corridor").transform;
    }
}
