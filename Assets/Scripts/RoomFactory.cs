using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFactory : MonoBehaviour
{
    public RoomManager defaultRoom;
    public TestTall test;
    public DiningArea diningRoom;

    public void InitializeScripts()
    {
        // empty tall and short rooms
        defaultRoom = GetComponent<RoomManager>();
        test = GetComponent<TestTall>();

        diningRoom = GetComponent<DiningArea>();
    }

    // factory for the different room scripts
    public void ChooseRoomType(int index, Room[] rooms)
    {
        int choice = Random.Range(0, 10);

        if (choice > 1)
        {
            diningRoom.SetupScene(rooms[index]);
        }
        else if (choice <= 1)
        {
            test.SetupScene(rooms[index]);
        }
    }
}