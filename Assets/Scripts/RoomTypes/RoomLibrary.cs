using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLibrary : RoomManager {

    public GameObject[] bookshelves;

    public void PlaceBookshelves()
    {
        int numBookshelves = (room.col - 4) / 2;
        print(numBookshelves);

        for (int i = 0; i < numBookshelves; i++)
        {
            GameObject bookshelf1 =
                Instantiate(bookshelves[Random.Range(0, bookshelves.Length)], 
                new Vector3((i * 2) + 3, 1.05f, room.rows - 3.45f) + room.vectorOffset, 
                Quaternion.Euler(new Vector3(-90, 90, 0))) as GameObject;
            bookshelf1.transform.SetParent(roomHolder);
            GameObject bookshelf2 =
                Instantiate(bookshelves[Random.Range(0, bookshelves.Length)],
                new Vector3((i * 2) + 3, 1.05f, room.rows - 4) + room.vectorOffset,
                Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
            bookshelf2.transform.SetParent(roomHolder);

            GameObject bookshelf3 =
                Instantiate(bookshelves[Random.Range(0, bookshelves.Length)],
                new Vector3((i * 2) + 3, 1.05f, 2.55f) + room.vectorOffset,
                Quaternion.Euler(new Vector3(-90, 90, 0))) as GameObject;
            bookshelf3.transform.SetParent(roomHolder);
            GameObject bookshelf4 =
                Instantiate(bookshelves[Random.Range(0, bookshelves.Length)],
                new Vector3((i * 2) + 3, 1.05f, 2) + room.vectorOffset,
                Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
            bookshelf4.transform.SetParent(roomHolder);
        }
    }

    public override void SetupScene(Room newRoom)
    {
        wallHeight = 2;
        ceilingHeight = 4;
        room = newRoom;

        roomHolder = new GameObject("Board").transform;

        base.RoomSetup();
        PlaceBookshelves();
        PlaceRoomWalls();
        PlaceTorches();
        InitialiseList();
    }
}
