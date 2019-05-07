using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Room
{
    public bool startRoomFlag = false;
    public Vector3 vectorOffset = new Vector3();
    public Transform roomHolder;
    public bool lightMade = false;

    public int rows;
    public int col;

    public Direction entranceDir;
    public Direction[] exitDirs;

    /*  Vector3 exitPos = new Vector3(-1, (room.rows / 2) + Random.Range(-1, 1), 0f) + room.vectorOffset;
        room.roomExits[3] = exitPos; */

    public List<Vector3> roomExits = new List<Vector3>();

    public void SetupRoom(int maxWidth, int maxHeight, Vector3 startPos)
    {
        rows = Random.Range(10, maxHeight);
        col = Random.Range(10, maxWidth);
        vectorOffset = startPos;
    }
}
