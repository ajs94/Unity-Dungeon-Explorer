using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class RoomManager : MonoBehaviour
{
    public float wallHeight = 1;
    public float ceilingHeight = 2;

    public GameObject torch;
    public GameObject[] floorTiles;
    public GameObject[] ceilingTiles;
    public GameObject[] wallTiles;

    public List<Vector3> gridPosition = new List<Vector3>();

    public Room room;

    public void InitialiseList()
    {
        gridPosition.Clear();

        //Loop through x axis (columns).
        for (int x = 0; x <= room.col; x++)
        {
            //Within each column, loop through y axis (rows).
            for (int y = 0; y < room.rows; y++)
            {
                gridPosition.Add(new Vector3(x, 0f, y) + room.vectorOffset);
            }
        }
    }

    // Blank else if's are special/wall tiles unimplemented
    public void RoomSetup()
    {
        for (float x = 0; x < room.col; x++)
        {
            for (int y = 0; y < room.rows; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

                Collider[] intersecting = Physics.OverlapSphere(new Vector3(x, 0f, y) + room.vectorOffset, .1f);
                if (intersecting.Length != 0)
                {
                    // if object exists here
                }
                else if (room.roomExits.Contains(new Vector3(x, 0f, y) + room.vectorOffset))
                {
                    // if its a room exit tile
                }
                else
                {
                    GameObject instance =
                        Instantiate(toInstantiate, new Vector3(x, 0f, y) + room.vectorOffset, Quaternion.identity) as GameObject;
                    instance.transform.SetParent(room.roomHolder);
                    GameObject instance2 =
                        Instantiate(ceilingTiles[Random.Range(0, ceilingTiles.Length)], new Vector3(x, ceilingHeight, y) + room.vectorOffset, Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
                    instance2.transform.SetParent(room.roomHolder);
                }
            }
        }
    }

    public void PlaceRoomWalls()
    {
        for (float x = 0; x < room.col; x++)
        {
            // north
            Collider[] intersecting = Physics.OverlapSphere(new Vector3(x, 1f, room.rows - .1f) + room.vectorOffset, .4f);
            if (intersecting.Length == 0)
            {
                GameObject instance =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], 
                    new Vector3(x, wallHeight, room.rows - .5f) + room.vectorOffset, 
                    Quaternion.identity) as GameObject;
                instance.transform.SetParent(room.roomHolder);
            }
            else
            {
                GameObject instance4 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], 
                    new Vector3(x, wallHeight + 2, room.rows -.5f) + room.vectorOffset, 
                    Quaternion.identity) as GameObject;
                instance4.transform.SetParent(room.roomHolder);
            }
            // south
            intersecting = Physics.OverlapSphere(new Vector3(x, 1f, -.9f) + room.vectorOffset, .4f);
            if (intersecting.Length == 0)
            {
                GameObject instance =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], 
                    new Vector3(x, wallHeight, -.5f) + room.vectorOffset, 
                    Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                instance.transform.SetParent(room.roomHolder);
            }
            else
            {
                GameObject instance4 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], 
                    new Vector3(x, wallHeight + 2, -.5f) + room.vectorOffset, 
                    Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                instance4.transform.SetParent(room.roomHolder);
            }
        }
        for (float z = 0; z < room.rows; z++)
        {
            // east
            Collider[] intersecting = Physics.OverlapSphere(new Vector3(room.col - .1f, 1f, z) + room.vectorOffset, .4f);
            if (intersecting.Length == 0)
            {
                GameObject instance =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], 
                    new Vector3(room.col - .5f, wallHeight, z) + room.vectorOffset, 
                    Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                instance.transform.SetParent(room.roomHolder);
            }
            else
            {
                GameObject instance4 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], 
                    new Vector3(room.col - .5f, wallHeight + 2, z) + room.vectorOffset, 
                    Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                instance4.transform.SetParent(room.roomHolder);
            }
            // west
            intersecting = Physics.OverlapSphere(new Vector3(-.9f, 1f, z) + room.vectorOffset, .4f);
            if (intersecting.Length == 0)
            {
                GameObject instance =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], 
                    new Vector3(-.5f, wallHeight, z) + room.vectorOffset, 
                    Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                instance.transform.SetParent(room.roomHolder);
            }
            else
            {
                GameObject instance =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], 
                    new Vector3(  -.5f, wallHeight + 2, z) + room.vectorOffset, 
                    Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                instance.transform.SetParent(room.roomHolder);
            }
        }
    }

    // maybe move this to the corridor class?
    public void PlaceTorches()
    {
        // int choice = Random.Range(0, 2);

        if (!room.lightMade)
        {
            GameObject[] lights = GameObject.FindGameObjectsWithTag("light");
            int choice = Random.Range(0, 4);

            // bottom
            if (choice == 0)
            {
                Vector3 pos = room.vectorOffset + new Vector3(Random.Range(0, room.col), 1, 0);
                for (int i = 0; i < lights.Length; i++)
                {
                    if (Vector3.Distance(pos, lights[i].transform.position) < 70)
                    {
                        room.lightMade = true;
                    }
                }

                Collider[] intersecting = Physics.OverlapSphere(pos, .6f);
                if (intersecting.Length == 0 && !room.lightMade)
                {
                    GameObject instance =
                        Instantiate(torch, pos + new Vector3(0, 0, -.4f),
                        Quaternion.identity) as GameObject;
                    instance.transform.SetParent(room.roomHolder);
                }
            }
            // top
            else if (choice == 1)
            {
                Vector3 pos = room.vectorOffset + new Vector3(Random.Range(0, room.col), 1, room.rows-1);
                for (int i = 0; i < lights.Length; i++)
                {
                    if (Vector3.Distance(pos, lights[i].transform.position) < 70)
                    {
                        room.lightMade = true;
                    }
                }

                Collider[] intersecting = Physics.OverlapSphere(pos, .6f);
                if (intersecting.Length == 0 && !room.lightMade)
                {
                    GameObject instance =
                        Instantiate(torch, pos + new Vector3(0, 0, .4f),
                        Quaternion.identity) as GameObject;
                    instance.transform.SetParent(room.roomHolder);
                }
            }
            // left
            else if (choice == 2)
            {
                Vector3 pos = room.vectorOffset + new Vector3(0, 1, Random.Range(0, room.rows));
                for (int i = 0; i < lights.Length; i++)
                {
                    if (Vector3.Distance(pos, lights[i].transform.position) < 70)
                    {
                        room.lightMade = true;
                    }
                }

                Collider[] intersecting = Physics.OverlapSphere(pos, .6f);
                if (intersecting.Length == 0 && !room.lightMade)
                {
                    GameObject instance =
                        Instantiate(torch, pos + new Vector3(-.4f, 0, 0),
                        Quaternion.identity) as GameObject;
                    instance.transform.SetParent(room.roomHolder);
                }
            }
            // right
            else if (choice == 3)
            {
                Vector3 pos = room.vectorOffset + new Vector3(room.col - 1, 1, Random.Range(0, room.rows));
                for (int i = 0; i < lights.Length; i++)
                {
                    if (Vector3.Distance(pos, lights[i].transform.position) < 70)
                    {
                        room.lightMade = true;
                    }
                }

                Collider[] intersecting = Physics.OverlapSphere(pos, .6f);
                if (intersecting.Length == 0 && !room.lightMade)
                {
                    GameObject instance =
                        Instantiate(torch, pos + new Vector3(.4f, 0, 0),
                        Quaternion.identity) as GameObject;
                    instance.transform.SetParent(room.roomHolder);
                }
            }
            room.lightMade = true;
        }
    }

    public virtual void SetupScene(Room newRoom)
    {
        room = newRoom;
        room.roomHolder = new GameObject("Room").transform;

        RoomSetup();
        PlaceTorches();
        PlaceRoomWalls();
        InitialiseList();
    }
}


