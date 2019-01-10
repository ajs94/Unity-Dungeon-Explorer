/*
public void CreateVerticalDoorway(Vector3 offset)
{
    currentCorridor.corridorWallHolder = new GameObject("CorridorWalls").transform;

    if (corridorWidth == 2)
    {
        Collider[] intersecting1 = Physics.OverlapSphere(new Vector3(0, .5f, 0) + offset, .4f);
        Collider[] intersecting2 = Physics.OverlapSphere(new Vector3(1, .5f, 0) + offset, .4f);

        if (intersecting1.Length == 0 && intersecting2.Length == 0)
        {
            GameObject instance =
                        Instantiate(door, currentPos + new Vector3(.025f, wallHeight, 0) + offset, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            instance.transform.SetParent(currentCorridor.corridorWallHolder);
            GameObject instance2 =
                        Instantiate(door, currentPos + new Vector3(.975f, wallHeight, 0) + offset, Quaternion.Euler(new Vector3(0, -180, 0))) as GameObject;
            instance2.transform.SetParent(currentCorridor.corridorWallHolder);
            GameObject instanceWall1 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(1.5f, wallHeight, 0) + offset, Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
            instanceWall1.transform.SetParent(currentCorridor.corridorWallHolder);
            GameObject instanceWall2 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(-.5f, wallHeight, 0) + offset, Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
            instanceWall2.transform.SetParent(currentCorridor.corridorWallHolder);
            GameObject instance3 =
                       Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(0, wallHeight * 3, .5f) + offset, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
            instance3.transform.SetParent(currentCorridor.corridorWallHolder);
            GameObject instance4 =
                        Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(0, wallHeight * 3, -.5f) + offset, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            instance4.transform.SetParent(currentCorridor.corridorWallHolder);
            GameObject instance5 =
                       Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(1, wallHeight * 3, .5f) + offset, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
            instance5.transform.SetParent(currentCorridor.corridorWallHolder);
            GameObject instance6 =
                       Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(1, wallHeight * 3, -.5f) + offset, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            instance6.transform.SetParent(currentCorridor.corridorWallHolder);
        }
    }
    else
    {
        for (int i = 0; i < corridorWidth; i++)
        {
            if (i == (corridorWidth / 2))
            {
                GameObject instance =
                    Instantiate(door, currentPos + new Vector3(i - .025f, wallHeight, 0) + offset, Quaternion.Euler(new Vector3(0, -180, 0))) as GameObject;
                instance.transform.SetParent(currentCorridor.corridorWallHolder);
                GameObject instance2 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i + .5f, wallHeight, 0) + offset, Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                instance2.transform.SetParent(currentCorridor.corridorWallHolder);

                GameObject instance3 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i, wallHeight * 3, .5f) + offset, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                instance3.transform.SetParent(currentCorridor.corridorWallHolder);
                GameObject instance4 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i, wallHeight * 3, -.5f) + offset, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                instance4.transform.SetParent(currentCorridor.corridorWallHolder);
            }
            else if (i == (corridorWidth / 2) - 1)
            {
                GameObject instance =
                    Instantiate(door, currentPos + new Vector3(i + .025f, wallHeight, 0) + offset, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                instance.transform.SetParent(currentCorridor.corridorWallHolder);
                GameObject instance2 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i - .5f, wallHeight, 0) + offset, Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                instance2.transform.SetParent(currentCorridor.corridorWallHolder);

                GameObject instance3 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i, wallHeight * 3, .5f) + offset, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                instance3.transform.SetParent(currentCorridor.corridorWallHolder);
                GameObject instance4 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(i, wallHeight * 3, -.5f) + offset, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                instance4.transform.SetParent(currentCorridor.corridorWallHolder);
            }
            else
            {
                GameObject instance =
                    Instantiate(tallWallTiles[Random.Range(0, tallWallTiles.Length)], currentPos + new Vector3(i, tallWallHeight, .5f) + offset, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                instance.transform.SetParent(currentCorridor.corridorWallHolder);
                GameObject instance2 =
                    Instantiate(tallWallTiles[Random.Range(0, tallWallTiles.Length)], currentPos + new Vector3(i, tallWallHeight, -.5f) + offset, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                instance2.transform.SetParent(currentCorridor.corridorWallHolder);
            }
        }
    }
}

public void CreateHorizDoorway(Vector3 offset)
{
    currentCorridor.corridorWallHolder = new GameObject("CorridorWalls").transform;

    if (corridorWidth == 2)
    {

        GameObject instance =
            Instantiate(door, currentPos + new Vector3(0, wallHeight, .975f) + offset, Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
        instance.transform.SetParent(currentCorridor.corridorWallHolder);
        GameObject instance2 =
            Instantiate(door, currentPos + new Vector3(0, wallHeight, .025f) + offset, Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
        instance2.transform.SetParent(currentCorridor.corridorWallHolder);
        GameObject instanceWall1 =
            Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(0, wallHeight, 1.5f) + offset, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        instanceWall1.transform.SetParent(currentCorridor.corridorWallHolder);
        GameObject instanceWall2 =
            Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(0, wallHeight, -.5f) + offset, Quaternion.Euler(new Vector3(0, -180, 0))) as GameObject;
        instanceWall2.transform.SetParent(currentCorridor.corridorWallHolder);
        GameObject instance3 =
            Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(.5f, wallHeight * 3, 0) + offset, Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
        instance3.transform.SetParent(currentCorridor.corridorWallHolder);
        GameObject instance4 =
           Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(-.5f, wallHeight * 3, 0) + offset, Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
        instance4.transform.SetParent(currentCorridor.corridorWallHolder);
        GameObject instance5 =
            Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(.5f, wallHeight * 3, 1) + offset, Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
        instance5.transform.SetParent(currentCorridor.corridorWallHolder);
        GameObject instance6 =
           Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(-.5f, wallHeight * 3, 1) + offset, Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
        instance6.transform.SetParent(currentCorridor.corridorWallHolder);
    }
    else
    {
        for (int i = 0; i < corridorWidth; i++)
        {
            if (i == (corridorWidth / 2))
            {
                GameObject instance =
                    Instantiate(door, currentPos + new Vector3(0, wallHeight, i - .025f) + offset, Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                instance.transform.SetParent(currentCorridor.corridorWallHolder);
                GameObject instance2 =
                   Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(0, wallHeight, i + .5f) + offset, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                instance2.transform.SetParent(currentCorridor.corridorWallHolder);

                GameObject instance3 =
                Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(.5f, wallHeight * 3, i) + offset, Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                instance3.transform.SetParent(currentCorridor.corridorWallHolder);
                GameObject instance4 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(-.5f, wallHeight * 3, i) + offset, Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                instance4.transform.SetParent(currentCorridor.corridorWallHolder);
            }
            else if (i == (corridorWidth / 2) - 1)
            {
                GameObject instance =
                    Instantiate(door, currentPos + new Vector3(0, wallHeight, i + .025f) + offset, Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                instance.transform.SetParent(currentCorridor.corridorWallHolder);
                GameObject instance2 =
                   Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(0, wallHeight, i - .5f) + offset, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                instance2.transform.SetParent(currentCorridor.corridorWallHolder);

                GameObject instance3 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(.5f, wallHeight * 3, i) + offset, Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                instance3.transform.SetParent(currentCorridor.corridorWallHolder);
                GameObject instance4 =
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], currentPos + new Vector3(-.5f, wallHeight * 3, i) + offset, Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                instance4.transform.SetParent(currentCorridor.corridorWallHolder);
            }
            else
            {
                GameObject instance =
                   Instantiate(tallWallTiles[Random.Range(0, tallWallTiles.Length)], currentPos + new Vector3(.5f, tallWallHeight, i) + offset, Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
                instance.transform.SetParent(currentCorridor.corridorWallHolder);
                GameObject instance2 =
                   Instantiate(tallWallTiles[Random.Range(0, tallWallTiles.Length)], currentPos + new Vector3(-.5f, tallWallHeight, i) + offset, Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                instance2.transform.SetParent(currentCorridor.corridorWallHolder);
            }
        }
    }
}*/