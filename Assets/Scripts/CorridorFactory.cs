using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CorridorType
{
    Default, Tall
}

public class CorridorFactory : MonoBehaviour
{
    public CorridorManager defaultCorrdior;
    public CorridorTestTall test;

    public void InitializeScripts()
    {
        // empty tall and short corridors
        defaultCorrdior = GetComponent<CorridorManager>();
        test = GetComponent<CorridorTestTall>();
    }

    // factory for the different corridor scripts
    public void ChooseCorridorType(int index, int bestIndex, Corridor corridor, Room[] rooms, bool inOut)
    {
        int choice = Random.Range(0, 10);

        if (choice > 4)
        {
            defaultCorrdior.SetupCorridor(corridor);
            defaultCorrdior.SetupConnection(rooms[index], rooms[bestIndex], inOut);
            defaultCorrdior.AddCorridorFloor(corridor);
            corridor.setType(CorridorType.Default);
        }
        else if (choice <= 4)
        {
            test.SetupCorridor(corridor);
            test.SetupConnection(rooms[index], rooms[bestIndex], inOut);
            test.AddCorridorFloor(corridor);
            corridor.setType(CorridorType.Tall);
        }
    }

    public void MakeCorridorWalls(Corridor corridor)
    {
        if (corridor.corridorType == CorridorType.Default)
        {
            defaultCorrdior.AddCorridorWalls(corridor);
        }
        else if (corridor.corridorType == CorridorType.Tall)
        {
            test.AddCorridorWalls(corridor);
        }
    }
}