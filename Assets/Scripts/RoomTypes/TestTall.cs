using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTall : RoomManager
{
    public override void SetupScene(Room newRoom)
    {
        wallHeight = 2;
        ceilingHeight = 4;

        room = newRoom;

        roomHolder = new GameObject("Board").transform;

        base.RoomSetup();
        PlaceRoomWalls();
        PlaceTorches();
        InitialiseList();
    }
}
