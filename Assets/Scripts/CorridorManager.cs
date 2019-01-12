using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class CorridorManager : MonoBehaviour
{
    public Corridor currentCorridor;

    public float wallHeight = 1;
    public float ceilingHeight = 2;

    public int corridorWidth;
    private int corridorWidthMax = 5;    // exclusive

    public GameObject door;
    public GameObject torch;

    public GameObject[] floorTiles;
    public GameObject[] ceilingTiles;
    public GameObject[] wallTiles;

    private Vector3 currentPos;
    private Vector3 startPos;
    private Vector3 endPos;

    private bool doorway1Made = false;
    private bool doorway2Made = false;

    public void setCorridor(Corridor corridor)
    {
        currentCorridor = corridor;
    }

    /* the creation functions for doorways
     * inOut is true if wall is facing north
     */ 
    public void CreateVerticalDoorway(Vector3 offset, bool inOut)
    {
        currentCorridor.corridorWallHolder = new GameObject("CorridorWalls").transform;
            
        for (int i = 0; i < corridorWidth; i++)
        {
            // build door and adjacent walls
            if (i == Math.Floor(corridorWidth / 2.0))
            {
                GameObject instance =
                    Instantiate(door, currentPos + new Vector3(i - .025f, wallHeight, 0) + offset, 
                    Quaternion.Euler(new Vector3(0, -180, 0))) as GameObject;
                instance.transform.SetParent(currentCorridor.corridorWallHolder);

                GameObject instance2 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i + .5f, wallHeight, 0) + offset, 
                    Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                instance2.transform.SetParent(currentCorridor.corridorWallHolder);

                // the walls above the doorway
                if (inOut)
                {
                    GameObject instance3 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i, wallHeight * 3, .5f) + offset, 
                        Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                    instance3.transform.SetParent(currentCorridor.corridorWallHolder);
                }
                else
                {
                    GameObject instance4 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i, wallHeight * 3, -.5f) + offset, 
                        Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                    instance4.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
            // build door and adjacent walls
            else if (i == Math.Floor(corridorWidth / 2.0) - 1)
            {
                GameObject instance =
                    Instantiate(door, currentPos + new Vector3(i + .025f, wallHeight, 0) + offset, 
                    Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                instance.transform.SetParent(currentCorridor.corridorWallHolder);

                GameObject instance2 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i - .5f, wallHeight, 0) + offset, 
                    Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                instance2.transform.SetParent(currentCorridor.corridorWallHolder);

                // the walls above the doorway
                if (inOut)
                {
                    GameObject instance3 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i, wallHeight * 3, .5f) + offset, 
                        Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                    instance3.transform.SetParent(currentCorridor.corridorWallHolder);
                }
                else
                {
                    GameObject instance4 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i, wallHeight * 3, -.5f) + offset, 
                        Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                    instance4.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
            // build walls facing into corridor
            else
            {
                if (inOut)
                {
                    GameObject instance =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i, wallHeight, .5f) + offset, 
                        Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                    instance.transform.SetParent(currentCorridor.corridorWallHolder);
                }
                else
                {
                    GameObject instance2 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i, wallHeight, -.5f) + offset, 
                        Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                    instance2.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
        }
    }

    public void CreateHorizDoorway(Vector3 offset, bool inOut)
    {
        currentCorridor.corridorWallHolder = new GameObject("CorridorWalls").transform;

        for (int i = 0; i < corridorWidth; i++)
        {
            // build door and adjacent walls
            if (i == (corridorWidth / 2))
            {
                GameObject instance =
                    Instantiate(door, currentPos + new Vector3(0, wallHeight, i - .025f) + offset, Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                instance.transform.SetParent(currentCorridor.corridorWallHolder);

                GameObject instance2 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(0, wallHeight, i + .5f) + offset, 
                    Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                instance2.transform.SetParent(currentCorridor.corridorWallHolder);

                // the walls above the doorway
                if (inOut)
                {
                    GameObject instance3 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(.5f, wallHeight * 3, i) + offset, 
                        Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                    instance3.transform.SetParent(currentCorridor.corridorWallHolder);
                }
                else
                {
                    GameObject instance4 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(-.5f, wallHeight * 3, i) + offset, 
                        Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                    instance4.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
            // build door and adjacent walls
            else if (i == (corridorWidth / 2) - 1)
            {
                GameObject instance =
                    Instantiate(door, currentPos + new Vector3(0, wallHeight, i + .025f) + offset, Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                instance.transform.SetParent(currentCorridor.corridorWallHolder);

                GameObject instance2 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(0, wallHeight, i - .5f) + offset, 
                    Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                instance2.transform.SetParent(currentCorridor.corridorWallHolder);

                // the walls above the doorway
                if (inOut)
                {
                    GameObject instance3 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(.5f, wallHeight * 3, i) + offset, 
                        Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                    instance3.transform.SetParent(currentCorridor.corridorWallHolder);
                }
                else
                {
                    GameObject instance4 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(-.5f, wallHeight * 3, i) + offset, 
                        Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                    instance4.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
            // build walls facing into corridor
            else
            {
                if (inOut)
                {
                    GameObject instance =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(.5f, wallHeight, i) + offset, 
                        Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                    instance.transform.SetParent(currentCorridor.corridorWallHolder);
                }
                else
                {
                    GameObject instance2 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(-.5f, wallHeight, i) + offset, 
                        Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                    instance2.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
            }
    }

    // to fill the space for when a doorway hits a collision
    public void VertDoorwayToWall(Vector3 offset, bool inOut)
    {
        for (int i = 0; i < corridorWidth; i++)
        {
            if (inOut)
            {
                Collider[] intersecting = Physics.OverlapSphere(new Vector3(i, wallHeight / 2, .25f) + currentPos + offset, .4f);
                if (intersecting.Length == 0)
                {
                    GameObject instance =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i, wallHeight, .5f) + offset,
                        Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                    instance.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
            else
            {
                Collider[] intersecting = Physics.OverlapSphere(new Vector3(i, wallHeight / 2, -.25f) + currentPos + offset, .4f);
                if (intersecting.Length == 0)
                {
                    GameObject instance2 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i, wallHeight, -.5f) + offset,
                        Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                    instance2.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
        }
    }
    public void HorzDoorwayToWall(Vector3 offset, bool inOut)
    {
        for (int i = 0; i < corridorWidth; i++)
        {
            if (inOut)
            {
                Collider[] intersecting = Physics.OverlapSphere(new Vector3(.25f, wallHeight / 2, i) + currentPos + offset, .4f);
                if (intersecting.Length == 0)
                {
                    GameObject instance =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(.5f, wallHeight, i) + offset,
                        Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                    instance.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
            else
            {
                Collider[] intersecting = Physics.OverlapSphere(new Vector3(-.25f, wallHeight / 2, i) + currentPos + offset, .4f);
                if (intersecting.Length == 0)
                {
                    GameObject instance2 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(-.5f, wallHeight, i) + offset,
                        Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                    instance2.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
        }
    }

    // TODO: if outside length/width make sure corridor is small enough
    public void AssignWidth(Room room1, Room room2)
    {
        startPos = room1.vectorOffset;

        corridorWidth = Random.Range(2, corridorWidthMax);

        // determine the width of the hallway
        // on the side
        if (((room1.vectorOffset.z + room1.rows) - room2.vectorOffset.z >= corridorWidth) &&
                (room1.vectorOffset.z + room1.rows) > room2.vectorOffset.z)
        {
            currentPos = new Vector3((room1.col / 2), 0f,
                Mathf.RoundToInt(room2.vectorOffset.z - room1.vectorOffset.z)) + room1.vectorOffset;
            endPos = new Vector3((room2.col / 2), 0f,
                currentPos.z - room2.vectorOffset.z) + room2.vectorOffset;
        }
        // above right-ish
        else if ((room1.vectorOffset.x + room1.col - room2.vectorOffset.x >= corridorWidth) &&
                (room1.vectorOffset.x + room1.col) > room2.vectorOffset.x &&
                (room1.vectorOffset.x < room2.vectorOffset.x))
        {
            currentPos = new Vector3(Mathf.RoundToInt(room2.vectorOffset.x - room1.vectorOffset.x), 0f, (room1.rows / 2)) + room1.vectorOffset;
            endPos = new Vector3(currentPos.x - room2.vectorOffset.x, 0f, (room2.col / 2)) + room2.vectorOffset;
        }
        // above left-ish
        else if ((room2.vectorOffset.x + room2.col - room1.vectorOffset.x >= corridorWidth) &&
                (room2.vectorOffset.x + room2.col) > room1.vectorOffset.x &&
                (room2.vectorOffset.x < room1.vectorOffset.x))
        {
            currentPos = new Vector3(0, 0f, (room2.rows / 2)) + room1.vectorOffset;
            endPos = new Vector3(currentPos.x - room2.vectorOffset.x, 0f, (room2.col / 2) + 1) + room2.vectorOffset;
        }
        // outside the length/ width
        else
        {
            // to the above right with not enough space b/t for a corridor
            if (room1.vectorOffset.x <= room2.vectorOffset.x &&
                room1.vectorOffset.x + room1.col > room2.vectorOffset.x)
            {
                currentPos = new Vector3(0, 0f, room1.rows / 2) + room1.vectorOffset;
                endPos = new Vector3((room2.col / 2), 0f, room2.rows / 2) + room2.vectorOffset;
            }
            // to the above left
            else if (room1.vectorOffset.x >= room2.vectorOffset.x &&
                     room2.vectorOffset.x + room2.col > room1.vectorOffset.x)
            {
                currentPos = new Vector3((room2.vectorOffset.x + room2.col - room1.vectorOffset.x + 1), 0f, room1.rows / 2) + room1.vectorOffset;
                endPos = new Vector3((room2.col / 2), 0f, room2.rows / 2) + room2.vectorOffset;
            }
            // directly left/ right
            else if (room1.vectorOffset.z + room1.rows + 1 > room2.vectorOffset.z &&
                    (room2.vectorOffset.x + room2.col < room1.vectorOffset.x ||
                     room1.vectorOffset.x + room1.col < room2.vectorOffset.x))
            {
                currentPos = new Vector3(room1.col / 2, 0f, room1.rows / 2) + room1.vectorOffset;
                endPos = new Vector3(room2.col / 2, 0f, room1.vectorOffset.z + room1.rows - room2.vectorOffset.z + 1) + room2.vectorOffset;
            }
            else
            {
                currentPos = new Vector3((room1.col / 2), 0f, room1.rows / 2) + room1.vectorOffset;
                endPos = new Vector3((room2.col / 2), 0f, room2.rows / 2) + room2.vectorOffset;
            }
        }
    }

    /* The start of the generation functions
     * 
     */
    public void SetupConnection(Room room1, Room room2, bool VerticalFirst)
    {
        // the one with the high z coordinate should be room2
        if (room1.vectorOffset.z > room2.vectorOffset.z)
        {
            Room temp = room1;
            room1 = room2;
            room2 = temp;
        }

        Vector3 pivot = new Vector3();

        AssignWidth(room1, room2);

        if (VerticalFirst)
        {
            BuildVertically(room1, room2);
            BuildHorizontally(room1, room2);
        }
        else
        {
            BuildHorizontally(room1, room2);
            BuildVertically(room1, room2);
        }

        doorway1Made = false;
        doorway2Made = false;
}

    public void BuildVertically(Room room1, Room room2)
    {
        while (currentPos.z < endPos.z)
        {
            for (int x = 0; x < corridorWidth; x++)
            {
                bool outsideRoom1 = (currentPos.x + x < room1.vectorOffset.x || currentPos.z < room1.vectorOffset.z) || 
                                    (currentPos.x > room1.vectorOffset.x + room1.col - 1 || currentPos.z > room1.vectorOffset.z + room1.rows - 1);
                bool outsideRoom2 =  (currentPos.x + x < room2.vectorOffset.x || currentPos.z < room2.vectorOffset.z) || 
                                    (currentPos.x > room2.vectorOffset.x + room2.col - 1 || currentPos.z > room2.vectorOffset.z + room2.rows - 1);

                if (outsideRoom1 && outsideRoom2)
                {
                    Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                    if (!doorway1Made && intersecting.Length != 0)
                    {
                        // doorway already there; run a failed routine
                        VertDoorwayToWall(new Vector3(0, 0, 0), true);
                        doorway1Made = true;
                    }
                    else if (!doorway1Made && intersecting.Length == 0)
                    {
                        CreateVerticalDoorway(new Vector3(0, 0, 0), true);
                        doorway1Made = true;
                    }
                    currentCorridor.corridorPosition.Add(currentPos + new Vector3(x, 0, 0));
                }
                else if (outsideRoom1 && !outsideRoom2 && doorway1Made)
                {
                    Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                    if (!doorway2Made && intersecting.Length != 0)
                    {
                        // doorway already there; run a failed routine
                        VertDoorwayToWall(new Vector3(0, 0, -1), false);
                        doorway2Made = true;
                    }
                    else if (!doorway2Made && intersecting.Length == 0)
                    {
                        CreateVerticalDoorway(new Vector3(0, 0, -1), false  );
                        doorway2Made = true;
                    }
                }
            }
            currentPos += Vector3.forward;
        }
    }

    public void BuildHorizontally(Room room1, Room room2)
    {
        // if to the right
        if (currentPos.x < endPos.x)
        {
            while (currentPos.x <= endPos.x)
            {
                for (int z = 0; z < corridorWidth; z++)
                {
                    bool outsideRoom1 = (currentPos.x < room1.vectorOffset.x || currentPos.z + z < room1.vectorOffset.z) || 
                                        (currentPos.x > room1.vectorOffset.x + room1.col - 1 || currentPos.z > room1.vectorOffset.z + room1.rows - 1);
                    bool outsideRoom2 =  (currentPos.x < room2.vectorOffset.x || currentPos.z + z < room2.vectorOffset.z) || 
                                        (currentPos.x > room2.vectorOffset.x + room2.col - 1 || currentPos.z > room2.vectorOffset.z + room2.rows - 1);

                    if (outsideRoom1 && outsideRoom2)
                    {
                        Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                        if (!doorway1Made && intersecting.Length != 0)
                        {
                            // doorway already there; run a failed routine
                            HorzDoorwayToWall(new Vector3(0, 0, 0), true);
                            doorway1Made = true;
                        }
                        else if (!doorway1Made && intersecting.Length == 0)
                        {
                            CreateHorizDoorway(new Vector3(0, 0, 0), true);
                            doorway1Made = true;
                        }
                        currentCorridor.corridorPosition.Add(currentPos + new Vector3(0, 0, z));
                    }
                    else if (outsideRoom1 && !outsideRoom2 && doorway1Made)
                    {
                        Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                        if (!doorway2Made && intersecting.Length != 0)
                        {
                            // doorway already there; run a failed routine
                            HorzDoorwayToWall(new Vector3(-1, 0, 0), false);
                            doorway2Made = true;
                        }
                        else if (!doorway2Made && intersecting.Length == 0)
                        {
                            CreateHorizDoorway(new Vector3(-1, 0, 0), false);
                            doorway2Made = true;
                        }
                    }
                }
                currentPos += Vector3.right;
            }
        }
        // if to the left
        else if (currentPos.x > endPos.x)
        {
            if (corridorWidth > 1)
                currentPos += new Vector3(corridorWidth - 1, 0, 0);

            while (currentPos.x >= endPos.x)
            {
                for (int z = 0; z < corridorWidth; z++)
                {
                    bool outsideRoom1 = (currentPos.x < room1.vectorOffset.x || currentPos.z + z < room1.vectorOffset.z) || 
                                        (currentPos.x > room1.vectorOffset.x + room1.col - 1 || currentPos.z > room1.vectorOffset.z + room1.rows - 1);
                    bool outsideRoom2 =  (currentPos.x < room2.vectorOffset.x || currentPos.z + z < room2.vectorOffset.z) || 
                                        (currentPos.x > room2.vectorOffset.x + room2.col - 1 || currentPos.z > room2.vectorOffset.z + room2.rows - 1);

                    if (outsideRoom1 && outsideRoom2)
                    {
                        Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                        if (!doorway1Made && intersecting.Length != 0)
                        {
                            // doorway already there; run a failed routine
                            HorzDoorwayToWall(new Vector3(0, 0, 0), false);
                            doorway1Made = true;
                        }
                        else if(!doorway1Made && intersecting.Length == 0)
                        {
                            CreateHorizDoorway(new Vector3(0, 0, 0), false);
                            doorway1Made = true;
                        }
                        currentCorridor.corridorPosition.Add(currentPos + new Vector3(0, 0, z));
                    }
                    else if (outsideRoom1 && !outsideRoom2 && doorway1Made)
                    {
                        Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                        if (!doorway2Made && intersecting.Length != 0)
                        {
                            // doorway already there; run a failed routine
                            CreateHorizDoorway(new Vector3(1, 0, 0), true);
                            doorway2Made = true;
                        }
                        else if (!doorway2Made && intersecting.Length == 0)
                        {
                            CreateHorizDoorway(new Vector3(1, 0, 0), true);
                            doorway2Made = true;
                        }
                    }
                }
                currentPos += Vector3.left;
            }
        }
    }
    public void AddCorridorFloor(Corridor corridor)
    {
        setCorridor(corridor);
        currentCorridor.corridorHolder = new GameObject("Corridors").transform;

        foreach (Vector3 tile in currentCorridor.corridorPosition)
        {
            Collider[] intersecting = Physics.OverlapSphere(tile, .1f);
            if (intersecting.Length == 0)
            {
                GameObject instance = Instantiate(floorTiles[Random.Range(0, floorTiles.Length)], tile, 
                    Quaternion.identity) as GameObject;
                instance.transform.SetParent(currentCorridor.corridorHolder);

                GameObject instance2 = Instantiate(ceilingTiles[Random.Range(0, ceilingTiles.Length)], tile + new Vector3(0, ceilingHeight, 0), 
                    Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
                instance2.transform.SetParent(currentCorridor.corridorHolder);
            }
        }
    }

    public void AddCorridorWalls(Corridor corridor)
    {
        setCorridor(corridor);

        currentCorridor.corridorWallHolder = new GameObject("CorridorWalls").transform;
        foreach (Vector3 tile in currentCorridor.corridorPosition)
        {
            Collider[] intersectingFloor = Physics.OverlapSphere(tile + Vector3.forward, .1f);
            if (intersectingFloor.Length == 0)
            {
                Collider[] intersectingWall = Physics.OverlapSphere(tile + new Vector3(0, wallHeight, .5f), .1f);
                if (intersectingWall.Length == 0)
                {
                    GameObject instance =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], tile + new Vector3(0, wallHeight, .5f), 
                        Quaternion.identity) as GameObject;
                    instance.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
            intersectingFloor = Physics.OverlapSphere(tile + Vector3.back, .1f);
            if (intersectingFloor.Length == 0)
            {
                Collider[] intersectingWall = Physics.OverlapSphere(tile + new Vector3(0, wallHeight, -.5f), .1f);
                if (intersectingWall.Length == 0)
                {
                    GameObject instance =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], tile + new Vector3(0, wallHeight, -.5f), 
                        Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                    instance.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
            intersectingFloor = Physics.OverlapSphere(tile + Vector3.right, .1f);
            if (intersectingFloor.Length == 0)
            {
                Collider[] intersectingWall = Physics.OverlapSphere(tile + new Vector3(.5f, wallHeight, 0), .1f);
                if (intersectingWall.Length == 0)
                {
                    GameObject instance =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], tile + new Vector3(.5f, wallHeight, 0), 
                        Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                    instance.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
            intersectingFloor = Physics.OverlapSphere(tile + Vector3.left, .1f);
            if (intersectingFloor.Length == 0)
            {
                Collider[] intersectingWall = Physics.OverlapSphere(tile + new Vector3(-.5f, wallHeight, 0), .1f);
                if (intersectingWall.Length == 0)
                {
                    GameObject instance =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], tile + new Vector3(-.5f, wallHeight, 0), 
                        Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                    instance.transform.SetParent(currentCorridor.corridorWallHolder);
                }
            }
        }
    }

    public void PlaceTorches()
    {

        GameObject instance =
            Instantiate(torch, new Vector3(startPos.x, wallHeight, endPos.z / 2) + startPos, Quaternion.identity) as GameObject;
        instance.transform.SetParent(currentCorridor.corridorHolder);

        if (startPos.z == endPos.z)
        {

        }
    }

}