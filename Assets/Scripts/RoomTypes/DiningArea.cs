using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiningArea : RoomManager
{
    public GameObject[] tableList;
    public GameObject[] chairList;

    public void PlaceTables()
    {
        if (room.col % 2 == 0)
        {
            for(int i = 2; i < room.rows - 3; i++)
            {
                GameObject chair1 =
                       Instantiate(chairList[Random.Range(0, chairList.Length)], new Vector3( (room.col/2) - 2, 0, i) + room.vectorOffset, Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
                chair1.transform.SetParent(roomHolder);
                GameObject table1 =
                       Instantiate(tableList[Random.Range(0, tableList.Length)], new Vector3((room.col / 2) - 1, 0, i) + room.vectorOffset, Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
                table1.transform.SetParent(roomHolder);
                GameObject table2 =
                       Instantiate(tableList[Random.Range(0, tableList.Length)], new Vector3(  (room.col / 2)  , 0, i) + room.vectorOffset, Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
                table2.transform.SetParent(roomHolder);
                GameObject chair2 =
                       Instantiate(chairList[Random.Range(0, chairList.Length)], new Vector3((room.col / 2) + 1, 0, i) + room.vectorOffset, Quaternion.Euler(new Vector3(-90, 90, 0))) as GameObject;
                chair2.transform.SetParent(roomHolder);
            }
        }
        else
        {
            for (int i = 2; i < room.rows - 3; i++)
            {
                GameObject chair1 =
                       Instantiate(chairList[Random.Range(0, chairList.Length)], new Vector3(2, 0, i) + room.vectorOffset, Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
                chair1.transform.SetParent(roomHolder);
                GameObject table1 =
                       Instantiate(tableList[Random.Range(0, tableList.Length)], new Vector3(3, 0, i) + room.vectorOffset, Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
                table1.transform.SetParent(roomHolder);
                GameObject table2 =
                       Instantiate(tableList[Random.Range(0, tableList.Length)], new Vector3(room.col - 4, 0, i) + room.vectorOffset, Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
                table2.transform.SetParent(roomHolder);
                GameObject chair2 =
                       Instantiate(chairList[Random.Range(0, chairList.Length)], new Vector3(room.col - 3, 0, i) + room.vectorOffset, Quaternion.Euler(new Vector3(-90, 90, 0))) as GameObject;
                chair2.transform.SetParent(roomHolder);
            }
        }
    }

    public override void SetupScene(Room newRoom)
    {
        wallHeight = 2;
        ceilingHeight = 4;

        room = newRoom;

        roomHolder = new GameObject("Board").transform;

        base.RoomSetup();
        PlaceTables();
        PlaceRoomWalls();
        PlaceTorches();
        InitialiseList();
    }
}
