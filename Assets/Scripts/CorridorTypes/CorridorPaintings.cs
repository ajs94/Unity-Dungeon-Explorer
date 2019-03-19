using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorPaintings : CorridorManager
{
    public GameObject[] paintings;

    public void MakePaintingsY()
    {
        foreach(Vector3 i in currentCorridor.corridorPosition)
        {
            Collider[] intersecting = Physics.OverlapSphere(i + new Vector3(-1, 0, 0), .4f);
            if (intersecting.Length == 0)
            {
                // make check and then make painting
                // check: distance from last painting and whether or not to make it
            }
        }
    }

    public override void SetupCorridor(Corridor corridor)
    {
        wallHeight = 2;
        ceilingHeight = 4;

        currentCorridor = corridor;
    }
}
