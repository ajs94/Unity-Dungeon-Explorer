using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomExit : RoomManager {

    public GameObject exitDoor;

    public void MakeExit()
    {
        GameObject portal =
            Instantiate(exitDoor,
            new Vector3((room.col / 2), 1, (room.rows / 2)) + room.vectorOffset,
            Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
    }

    public override void SetupScene(Room newRoom)
    {
        wallHeight = 2;
        ceilingHeight = 4;

        room = newRoom;

        roomHolder = new GameObject("Board").transform;

        base.RoomSetup();
        MakeExit();
        PlaceRoomWalls();
        PlaceTorches();
        InitialiseList();
    }
}
