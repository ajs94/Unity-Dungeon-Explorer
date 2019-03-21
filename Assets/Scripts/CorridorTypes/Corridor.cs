using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour
{

    public int corridorWidth;

    public List<Vector3> corridorPosition = new List<Vector3>();
    public Transform corridorHolder;
    public Transform corridorWallHolder;

    public CorridorType corridorType;

    private int corridorWidthMax = 4;

    private Vector3 currentPos;
    private Vector3 endPos;

    public void SetupCorridor()
    {
        corridorWidth = Random.Range(2, corridorWidthMax);
    }

    public void setType(CorridorType newType)
    {
        corridorType = newType;
    }
}