using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorMined : CorridorManager {

    public override void AssignWidth(Room room1, Room room2)
    {
        startPos = room1.vectorOffset;

        currentCorridor.corridorWidth = 2;

        // determine the width of the hallway
        // on the side
        if (((room1.vectorOffset.z + room1.rows) - room2.vectorOffset.z >= currentCorridor.corridorWidth) &&
                (room1.vectorOffset.z + room1.rows) > room2.vectorOffset.z)
        {
            currentPos = new Vector3((room1.col / 2), 0f,
                Mathf.RoundToInt(room2.vectorOffset.z - room1.vectorOffset.z)) + room1.vectorOffset;
            endPos = new Vector3((room2.col / 2), 0f,
                currentPos.z - room2.vectorOffset.z) + room2.vectorOffset;
        }
        // above right-ish
        else if ((room1.vectorOffset.x + room1.col - room2.vectorOffset.x >= currentCorridor.corridorWidth) &&
                (room1.vectorOffset.x + room1.col) > room2.vectorOffset.x &&
                (room1.vectorOffset.x < room2.vectorOffset.x))
        {
            currentPos = new Vector3(Mathf.RoundToInt(room2.vectorOffset.x - room1.vectorOffset.x), 0f, (room1.rows / 2)) + room1.vectorOffset;
            endPos = new Vector3(currentPos.x - room2.vectorOffset.x, 0f, (room2.col / 2)) + room2.vectorOffset;
        }
        // above left-ish
        else if ((room2.vectorOffset.x + room2.col - room1.vectorOffset.x >= currentCorridor.corridorWidth) &&
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

    public override void SetupCorridor(Corridor corridor)
    {
        wallHeight = 2;
        ceilingHeight = 4;

        currentCorridor = corridor;
    }
}
