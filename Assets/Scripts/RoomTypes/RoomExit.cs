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
        portal.transform.SetParent(room.roomHolder);
    }

    public override void SetupScene(Room newRoom)
    {
        wallHeight = 2;
        ceilingHeight = 4;

        room = newRoom;

        room.roomHolder = new GameObject("Room").transform;

        base.RoomSetup();
        MakeExit();
        PlaceRoomWalls();
        PlaceTorches();
        InitialiseList();
    }
}
