using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFactory : MonoBehaviour
{
    public RoomManager defaultRoom;
    public TestTall test;
    public DiningArea diningRoom;
    public RoomTables tableRoom;

    public void InitializeScripts()
    {
        // empty tall and short rooms
        defaultRoom = GetComponent<RoomManager>();
        test = GetComponent<TestTall>();

        diningRoom = GetComponent<DiningArea>();
        tableRoom = GetComponent<RoomTables>();
    }

    // factory for the different room scripts
    public void ChooseRoomType(int index, Room[] rooms)
    {
        int choice = Random.Range(0, 5);

        if (choice >= 2)
        {
            tableRoom.SetupScene(rooms[index]);
        }
        else if (choice == 1)
        {
            diningRoom.SetupScene(rooms[index]);
        }
        else if (choice == 0)
        {
            test.SetupScene(rooms[index]);
        }
    }
}