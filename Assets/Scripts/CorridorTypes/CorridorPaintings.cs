using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorPaintings : CorridorManager
{
    public List<GameObject> paintings;

    public void AddPaintingsX(Corridor corridor)
    {
        currentCorridor = corridor;
        int count = 0;

        foreach (Vector3 i in currentCorridor.corridorPosition)
        {
            Collider[] intersecting = Physics.OverlapSphere(i + new Vector3(0, 0, 1), .4f);
            if (intersecting.Length == 0 && count > 8 && paintings.Count != 0)
            {
                int choice = Random.Range(0, 5);
                if (choice == 0)
                {
                    int index = Random.Range(0, paintings.Count);
                    GameObject instance = Instantiate(paintings[index], i + new Vector3(0, 1.3f, .2f),
                            Quaternion.Euler(new Vector3(-90, 270, 0))) as GameObject;
                    instance.transform.SetParent(currentCorridor.corridorHolder);
                    paintings.Remove(paintings[index]);
                }
            }
            count++;
        }
    }

    public void AddPaintingsY(Corridor corridor)
    {
        currentCorridor = corridor;
        int count = 0;

        foreach (Vector3 i in currentCorridor.corridorPosition)
        {
            Collider[] intersecting = Physics.OverlapSphere(i + new Vector3(-1, 0, 0), .4f);
            if (intersecting.Length == 0 && count > 8 && paintings.Count != 0)
            {
                int choice = Random.Range(0, 5);
                if (choice == 0)
                {
                    int index = Random.Range(0, paintings.Count);
                    GameObject instance = Instantiate(paintings[index], i + new Vector3(-.2f, 1.3f, 0),
                            Quaternion.Euler(new Vector3(-90, 180, 0))) as GameObject;
                    instance.transform.SetParent(currentCorridor.corridorHolder);
                    paintings.Remove(paintings[index]);
                }
            }
            count++;
        }
    }

    public override void SetupCorridor(Corridor corridor)
    {
        wallHeight = 2;
        ceilingHeight = 4;

        currentCorridor = corridor;
        currentCorridor.corridorHolder = new GameObject("Corridor").transform;
    }
}
