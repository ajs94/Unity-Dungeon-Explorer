using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFactory : MonoBehaviour
{
    // test/empty rooms
    public RoomManager defaultRoom;
    public TestTall test;

    // actual gameplay rooms
    public RoomExit exitPortal;
    public DiningArea diningRoom;
    public RoomTables tableRoom;
    public RoomLibrary libraryRoom;


    public void InitializeScripts()
    {
        // empty tall and short rooms
        defaultRoom = GetComponent<RoomManager>();
        test = GetComponent<TestTall>();

        exitPortal = GetComponent<RoomExit>();
        diningRoom = GetComponent<DiningArea>();
        tableRoom = GetComponent<RoomTables>();
        libraryRoom = GetComponent<RoomLibrary>();
    }

    // factory for the different room scripts
    public void ChooseRoomType(int index, Room[] rooms)
    {
        int choice = Random.Range(0, 6);

        if (index == rooms.Length - 1)
        {
            exitPortal.SetupScene(rooms[index]);
        }
        else if (choice <= 1)
        {
            diningRoom.SetupScene(rooms[index]);
        }
        else if (choice <= 3)
        {
            libraryRoom.SetupScene(rooms[index]);
        }
        else if (choice <= 5)
        {
            tableRoom.SetupScene(rooms[index]);
        }
        // the test room, not meant to be actually made
        else
        {
            test.SetupScene(rooms[index]);
        }
    }
}