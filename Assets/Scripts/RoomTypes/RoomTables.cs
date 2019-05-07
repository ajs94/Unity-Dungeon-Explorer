using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTables : RoomManager {

    public GameObject[] tableList;
    public GameObject[] chairList;
    public GameObject[] shelfList;

    public void PlaceTables()
    {
        SetupTable(new Vector3(2 + Random.Range(0, 2), 0, 2 + Random.Range(0, 2)));
        SetupTable(new Vector3(room.col - 3 - Random.Range(0, 2), 0, 2 + Random.Range(0, 2)));
        SetupTable(new Vector3(2 + Random.Range(0, 2), 0, room.rows - 3 - Random.Range(0, 2)));
        SetupTable(new Vector3(room.col - 3 - Random.Range(0, 2), 0, room.rows - 3 - Random.Range(0, 2)));

        if (room.col * room.rows >= 120)
        {
            SetupShelves(new Vector3(room.col / 2, 0, room.rows / 2));
        }
    }

    public void SetupTable(Vector3 pos)
    {
        // build the table
        GameObject table =
            Instantiate(tableList[Random.Range(0, tableList.Length)], 
            pos + new Vector3(0, .5f, 0) + room.vectorOffset,
            Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
        table.transform.SetParent(room.roomHolder);

        // surround it on 4 sides with chairs
        GameObject chair1 =
            Instantiate(chairList[Random.Range(0, chairList.Length)], 
            pos + new Vector3(0, 0, 1) + room.vectorOffset, 
            Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
        chair1.transform.SetParent(room.roomHolder);
        GameObject chair2 =
            Instantiate(chairList[Random.Range(0, chairList.Length)],
            pos + new Vector3(0, 0, -1) + room.vectorOffset,
            Quaternion.Euler(new Vector3(-90, 180, 0))) as GameObject;
        chair2.transform.SetParent(room.roomHolder);
        GameObject chair3 =
            Instantiate(chairList[Random.Range(0, chairList.Length)],
            pos + new Vector3(1, 0, 0) + room.vectorOffset,
            Quaternion.Euler(new Vector3(-90, 90, 0))) as GameObject;
        chair3.transform.SetParent(room.roomHolder);
        GameObject chair4 =
            Instantiate(chairList[Random.Range(0, chairList.Length)],
            pos + new Vector3(-1, 0, 0) + room.vectorOffset,
            Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
        chair4.transform.SetParent(room.roomHolder);
    }

    public void SetupShelves(Vector3 pos)
    {
        GameObject shelf1 =
            Instantiate(shelfList[Random.Range(0, shelfList.Length)],
            pos + room.vectorOffset,
            Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
        shelf1.transform.SetParent(room.roomHolder);
        GameObject shelf2 =
            Instantiate(shelfList[Random.Range(0, shelfList.Length)],
            pos + new Vector3(-1, 0, -1) + room.vectorOffset,
            Quaternion.Euler(new Vector3(-90, 180, 0))) as GameObject;
        shelf2.transform.SetParent(room.roomHolder);

    }

    public override void SetupScene(Room newRoom)
    {
        wallHeight = 2;
        ceilingHeight = 4;

        room = newRoom;

        room.roomHolder = new GameObject("Room").transform;

        base.RoomSetup();
        PlaceTables();
        PlaceTorches();
        PlaceRoomWalls();
        InitialiseList();
    }
}
