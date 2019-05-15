using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CorridorType
{
    Default, Tall, Mined, Painting
}

public class CorridorFactory : MonoBehaviour
{
    public CorridorManager defaultCorrdior;
    public CorridorTestTall test;
    public CorridorMined minedCorridor;
    public CorridorPaintings paintingCorridor;

    public bool paintingMade = false;

    public void InitializeScripts()
    {
        // empty tall and short corridors
        defaultCorrdior = GetComponent<CorridorManager>();
        test = GetComponent<CorridorTestTall>();
        
        // designed corridors for actual gameplay
        minedCorridor = GetComponent<CorridorMined>();
        paintingCorridor = GetComponent<CorridorPaintings>();
    }

    // factory for the different corridor scripts
    public void ChooseCorridorType(int index, int bestIndex, Corridor corridor, Room[] rooms, bool inOut)
    {
        int choice = Random.Range(0, 10);

        if (!paintingMade)
        {
            paintingCorridor.SetupCorridor(corridor);
            paintingCorridor.AssignWidth(rooms[index], rooms[bestIndex]);
            paintingCorridor.SetupConnection(rooms[index], rooms[bestIndex], inOut);
            paintingCorridor.AddCorridorFloor(corridor);
            corridor.setType(CorridorType.Painting);
            paintingMade = true;
        }
        else if (choice <= 1)
        {
            minedCorridor.SetupCorridor(corridor);
            minedCorridor.AssignWidth(rooms[index], rooms[bestIndex]);
            minedCorridor.SetupConnection(rooms[index], rooms[bestIndex], inOut);
            minedCorridor.AddCorridorFloor(corridor);
            corridor.setType(CorridorType.Mined);
        }
        else if (choice > 1)
        {
            test.SetupCorridor(corridor);
            test.AssignWidth(rooms[index], rooms[bestIndex]);
            test.SetupConnection(rooms[index], rooms[bestIndex], inOut);
            test.AddCorridorFloor(corridor);
            corridor.setType(CorridorType.Tall);
        }
    }

    public void MakeCorridorWalls(Corridor corridor)
    {
        if (corridor.corridorType == CorridorType.Mined)
        {
            minedCorridor.AddCorridorWalls(corridor);
        }
        else if (corridor.corridorType == CorridorType.Tall)
        {
            test.AddCorridorWalls(corridor);
        }
        else if (corridor.corridorType == CorridorType.Painting)
        {
            paintingCorridor.AddCorridorWalls(corridor);
            paintingCorridor.AddPaintingsY(corridor);
            paintingCorridor.AddPaintingsX(corridor);
        }
    }
}