using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour
{
    public List<Vector3> corridorPosition = new List<Vector3>();
    public Transform corridorHolder;
    public Transform corridorWallHolder;

    public CorridorType corridorType;

    private int corridorWidthMax = 4;
    public int corridorWidth;

    private Vector3 currentPos;
    private Vector3 endPos;

    public void setType(CorridorType newType)
    {
        corridorType = newType;
    }
}