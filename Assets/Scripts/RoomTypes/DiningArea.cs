using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiningArea : RoomManager
{
    public GameObject[] tableList;
    public GameObject[] chairList;
    public GameObject[] shelfList;
    public GameObject[] paintings;

    public void PlaceTables()
    {
        if (room.col % 2 == 0)
        {
            for(int i = 2; i < room.rows - 3; i++)
            {
                GameObject chair1 =
                       Instantiate(chairList[Random.Range(0, chairList.Length)], 
                       new Vector3( (room.col/2) - 2, 0, i) + room.vectorOffset, 
                       Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
                chair1.transform.SetParent(room.roomHolder);
                GameObject table1 =
                       Instantiate(tableList[Random.Range(0, tableList.Length)], 
                       new Vector3((room.col / 2) - 1, .5f, i) + room.vectorOffset, 
                       Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
                table1.transform.SetParent(room.roomHolder);
                GameObject table2 =
                       Instantiate(tableList[Random.Range(0, tableList.Length)], 
                       new Vector3(  (room.col / 2)  , .5f, i) + room.vectorOffset, 
                       Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
                table2.transform.SetParent(room.roomHolder);
                GameObject chair2 =
                       Instantiate(chairList[Random.Range(0, chairList.Length)], 
                       new Vector3((room.col / 2) + 1, 0, i) + room.vectorOffset, 
                       Quaternion.Euler(new Vector3(-90, 90, 0))) as GameObject;
                chair2.transform.SetParent(room.roomHolder);
            }
        }
        else
        {
            for (int i = 2; i < room.rows - 3; i++)
            {
                GameObject chair1 =
                       Instantiate(chairList[Random.Range(0, chairList.Length)], 
                       new Vector3(3, 0, i) + room.vectorOffset, 
                       Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
                chair1.transform.SetParent(room.roomHolder);
                GameObject table1 =
                       Instantiate(tableList[Random.Range(0, tableList.Length)], 
                       new Vector3(4, .5f, i) + room.vectorOffset, 
                       Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
                table1.transform.SetParent(room.roomHolder);
                GameObject table2 =
                       Instantiate(tableList[Random.Range(0, tableList.Length)], 
                       new Vector3(room.col - 5, .5f, i) + room.vectorOffset, 
                       Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
                table2.transform.SetParent(room.roomHolder);
                GameObject chair2 =
                       Instantiate(chairList[Random.Range(0, chairList.Length)], 
                       new Vector3(room.col - 4, 0, i) + room.vectorOffset, 
                       Quaternion.Euler(new Vector3(-90, 90, 0))) as GameObject;
                chair2.transform.SetParent(room.roomHolder);
            }
        }
    }

    public void AddSideObjects()
    {
        for (int i = 2; i < room.rows; i += 2)
        {
            Collider[] intersecting = Physics.OverlapSphere(room.vectorOffset + new Vector3(-1, 2, i - .5f), 1);
            int choice = Random.Range(0, 5);

            // 1/5 chance for 2 paintings and then 1/2 for each to be made
            if (intersecting.Length == 0 && choice == 1)
            {
                int choice1 = Random.Range(0, 2);
                if (choice1 == 0)
                {
                    GameObject painting1 =
                        Instantiate(paintings[Random.Range(0, paintings.Length)],
                        room.vectorOffset + new Vector3(-.2f, 1.3f, i),
                        Quaternion.Euler(new Vector3(-90, 180, 0))) as GameObject;
                    painting1.transform.SetParent(room.roomHolder);
                }
                int choice2 = Random.Range(0, 2);
                if (choice2 == 0)
                {
                    GameObject painting2 =
                        Instantiate(paintings[Random.Range(0, paintings.Length)],
                        room.vectorOffset + new Vector3(-.2f, 1.3f, i - 1),
                        Quaternion.Euler(new Vector3(-90, 180, 0))) as GameObject;
                    painting2.transform.SetParent(room.roomHolder);
                }
            }
            // shelf
            else if (intersecting.Length == 0 && choice != 0)
            {
                GameObject shelf1 =
                    Instantiate(shelfList[Random.Range(0, shelfList.Length)],
                    room.vectorOffset + new Vector3(0, 0, i),
                    Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
                shelf1.transform.SetParent(room.roomHolder);
            }
        }

        for (int i = 2; i < room.rows; i += 2)
        {
            Collider[] intersecting = Physics.OverlapSphere(room.vectorOffset + new Vector3(room.col + 1, 2, i - .5f), 1);
            int choice = Random.Range(0, 5);

            // 1/5 chance for paintings
            if (intersecting.Length == 0 && choice == 1)
            {
                GameObject painting1 =
                    Instantiate(paintings[Random.Range(0, paintings.Length)],
                    room.vectorOffset + new Vector3(room.col - .8f, 1.3f, i),
                    Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
                painting1.transform.SetParent(room.roomHolder);
                GameObject painting2 =
                    Instantiate(paintings[Random.Range(0, paintings.Length)],
                    room.vectorOffset + new Vector3(room.col - .8f, 1.3f, i - 1),
                    Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
                painting2.transform.SetParent(room.roomHolder);
            }
            // shelf
            else if (intersecting.Length == 0 && choice != 0)
            {
                GameObject shelf1 =
                    Instantiate(shelfList[Random.Range(0, shelfList.Length)],
                    room.vectorOffset + new Vector3(room.col - 1, 0, i - 1),
                    Quaternion.Euler(new Vector3(-90, 180, 0))) as GameObject;
                shelf1.transform.SetParent(room.roomHolder);
            }
        }
    }

    public override void SetupScene(Room newRoom)
    {
        wallHeight = 2;
        ceilingHeight = 4;

        room = newRoom;

        room.roomHolder = new GameObject("Room").transform;

        base.RoomSetup();
        PlaceTables();
        AddSideObjects();
        PlaceTorches();
        PlaceRoomWalls();
        InitialiseList();
    }
}
