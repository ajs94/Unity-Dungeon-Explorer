/*
 * public void ConnectRooms(Room room1, Room room2)
    {
        if (room1.vectorOffset.z > room2.vectorOffset.z)
        {
            Room temp = room1;
            room1 = room2;
            room2 = temp;
        }

        Vector3 pivot = new Vector3();
        bool doorwayMade = false;

        AssignWidth(room1, room2);

        // loop through the rows
        while (currentPos.z < endPos.z)
        {
            for (int x = 0; x < corridorWidth; x++)
            {
                bool outsideRoom1 = (currentPos.x + x < room1.vectorOffset.x || currentPos.z < room1.vectorOffset.z) || (
                                    currentPos.x + x > room1.vectorOffset.x + room1.col - 1 || currentPos.z > room1.vectorOffset.z + room1.rows - 1);
                bool ousideRoom2 = (currentPos.x + x < room2.vectorOffset.x || currentPos.z < room2.vectorOffset.z) || (
                                    currentPos.x + x > room2.vectorOffset.x + room2.col - 1 || currentPos.z > room2.vectorOffset.z + room2.rows - 1);

                if (outsideRoom1 && ousideRoom2)
                {
                    Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth/2);
                    if (!doorwayMade && intersecting.Length == 0)
                    {
                        CreateVerticalDoorway(new Vector3(0, 0, 0));
                        doorwayMade = true;
                    }
                    currentCorridor.corridorPosition.Add(currentPos + new Vector3(x, 0, 0));
                }
                else
                {
                    Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                    if (doorwayMade && intersecting.Length == 0)
                    {
                        CreateVerticalDoorway(new Vector3(0, 0, -1));
                        doorwayMade = false;
                    }
                }
            }
            currentPos += Vector3.forward;
        }

        pivot = currentPos;
        doorwayMade = false;

        // loop through the columns
        if (currentPos.x < endPos.x)
        {
            //if (corridorWidth > 1)
            //    currentPos += new Vector3(corridorWidth / 2, 0, corridorWidth / 2);

            while (currentPos.x <= endPos.x)
            {
                for (int z = 0; z < corridorWidth; z++)
                {
                    bool outsideRoom1 = (currentPos.x < room1.vectorOffset.x || currentPos.z + z < room1.vectorOffset.z) || (
                                        currentPos.x > room1.vectorOffset.x + room1.col - 1 || currentPos.z + z > room1.vectorOffset.z + room1.rows - 1);
                    bool ousideRoom2 = (currentPos.x < room2.vectorOffset.x || currentPos.z + z < room2.vectorOffset.z) || (
                                        currentPos.x > room2.vectorOffset.x + room2.col - 1 || currentPos.z + z > room2.vectorOffset.z + room2.rows - 1);

                    if (outsideRoom1 && ousideRoom2)
                    {
                        Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                        if (!doorwayMade && intersecting.Length == 0)
                        {
                            CreateHorizDoorway(new Vector3(0, 0, 0));
                            doorwayMade = true;
                        }
                        currentCorridor.corridorPosition.Add(currentPos + new Vector3(0, 0, z));
                    }
                    else
                    {
                        Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                        if (doorwayMade && intersecting.Length == 0)
                        {
                            CreateHorizDoorway(new Vector3(-1, 0, 0));
                            doorwayMade = false;
                        }
                    }
                }
                currentPos += Vector3.right;
            }
        }
        else if (currentPos.x > endPos.x)
        {
            if (corridorWidth > 1)
                currentPos += new Vector3(corridorWidth - 1, 0, 0);

            while (currentPos.x >= endPos.x)
            {
                for (int z = 0; z < corridorWidth; z++)
                {
                    bool outsideRoom1 = (currentPos.x < room1.vectorOffset.x || currentPos.z + z < room1.vectorOffset.z) || (
                                        currentPos.x > room1.vectorOffset.x + room1.col - 1 || currentPos.z + z > room1.vectorOffset.z + room1.rows - 1);
                    bool ousideRoom2 = (currentPos.x < room2.vectorOffset.x || currentPos.z + z < room2.vectorOffset.z) || (
                                        currentPos.x > room2.vectorOffset.x + room2.col - 1 || currentPos.z + z > room2.vectorOffset.z + room2.rows - 1);

                    if (outsideRoom1 && ousideRoom2)
                    {
                        Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                        if (!doorwayMade && intersecting.Length == 0)
                        {
                            CreateHorizDoorway(new Vector3(0, 0, 0));
                            doorwayMade = true;
                        }
                        currentCorridor.corridorPosition.Add(currentPos + new Vector3(0, 0, z));
                    }
                    else
                    {
                        Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                        if (doorwayMade && intersecting.Length == 0)
                        {
                            CreateHorizDoorway(new Vector3(1, 0, 0));
                            doorwayMade = false;
                        }
                    }
                }
                currentPos += Vector3.left;
            }
        }
    }

    public void ConnectClosestRooms(Room room1, Room room2)
    {
        if (room1.vectorOffset.z > room2.vectorOffset.z)
        {
            Room temp = room1;
            room1 = room2;
            room2 = temp;
        }

        Vector3 pivot = new Vector3();
        bool doorwayMade = false;

        AssignWidth(room1, room2);

        // loop through the columns
        if (currentPos.x < endPos.x)
        {
            //if (corridorWidth > 1)
            //    currentPos += new Vector3(corridorWidth / 2, 0, corridorWidth / 2);

            while (currentPos.x <= endPos.x)
            {
                for (int z = 0; z < corridorWidth; z++)
                {
                    bool outsideRoom1 = (currentPos.x < room1.vectorOffset.x || currentPos.z + z < room1.vectorOffset.z) || (
                                        currentPos.x > room1.vectorOffset.x + room1.col - 1 || currentPos.z + z > room1.vectorOffset.z + room1.rows - 1);
                    bool ousideRoom2 = (currentPos.x < room2.vectorOffset.x || currentPos.z + z < room2.vectorOffset.z) || (
                                        currentPos.x > room2.vectorOffset.x + room2.col - 1 || currentPos.z + z > room2.vectorOffset.z + room2.rows - 1);

                    if (outsideRoom1 && ousideRoom2)
                    {
                        Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                        if (!doorwayMade && intersecting.Length == 0)
                        {
                            CreateHorizDoorway(new Vector3(0, 0, 0));
                            doorwayMade = true;
                        }
                        else if (!doorwayMade && intersecting.Length != 0)
                        {
                            doorwayMade = true;
                        }
                        currentCorridor.corridorPosition.Add(currentPos + new Vector3(0, 0, z));
                    }
                    else
                    {
                        Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                        if (doorwayMade && intersecting.Length == 0)
                        {
                            CreateHorizDoorway(new Vector3(-1, 0, 0));
                            doorwayMade = false;
                        }
                    }
                }
                currentPos += Vector3.right;
            }
        }
        else if (currentPos.x > endPos.x)
        {
            if (corridorWidth > 1)
                currentPos += new Vector3(corridorWidth - 1, 0, 0);

            while (currentPos.x >= endPos.x)
            {
                for (int z = 0; z < corridorWidth; z++)
                {
                    bool outsideRoom1 = (currentPos.x < room1.vectorOffset.x || currentPos.z + z < room1.vectorOffset.z) || (
                                        currentPos.x > room1.vectorOffset.x + room1.col - 1 || currentPos.z + z > room1.vectorOffset.z + room1.rows - 1);
                    bool ousideRoom2 = (currentPos.x < room2.vectorOffset.x || currentPos.z + z < room2.vectorOffset.z) || (
                                        currentPos.x > room2.vectorOffset.x + room2.col - 1 || currentPos.z + z > room2.vectorOffset.z + room2.rows - 1);

                    if (outsideRoom1 && ousideRoom2)
                    {
                        Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                        if (!doorwayMade && intersecting.Length == 0)
                        {
                            CreateHorizDoorway(new Vector3(0, 0, 0));
                            doorwayMade = true;
                        }
                        else if (!doorwayMade && intersecting.Length != 0)
                        {
                            doorwayMade = true;
                        }
                        currentCorridor.corridorPosition.Add(currentPos + new Vector3(0, 0, z));
                    }
                    
                }
                currentPos += Vector3.left;
            }
        }

        pivot = currentPos;

        // loop through the rows
        while (currentPos.z < endPos.z)
        {
            for (int x = 0; x < corridorWidth; x++)
            {
                bool outsideRoom1 = (currentPos.x + x < room1.vectorOffset.x || currentPos.z < room1.vectorOffset.z) || (
                                    currentPos.x + x > room1.vectorOffset.x + room1.col - 1 || currentPos.z > room1.vectorOffset.z + room1.rows - 1);
                bool ousideRoom2 = (currentPos.x + x < room2.vectorOffset.x || currentPos.z < room2.vectorOffset.z) || (
                                    currentPos.x + x > room2.vectorOffset.x + room2.col - 1 || currentPos.z > room2.vectorOffset.z + room2.rows - 1);

                if (outsideRoom1 && ousideRoom2)
                {
                    Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                    if (!doorwayMade && intersecting.Length == 0)
                    {
                        CreateVerticalDoorway(new Vector3(0, 0, 0));
                        doorwayMade = true;
                    }
                    currentCorridor.corridorPosition.Add(currentPos + new Vector3(x, 0, 0));
                }
                else
                {
                    Collider[] intersecting = Physics.OverlapSphere(new Vector3(0, .5f, 0) + currentPos, corridorWidth / 2);
                    if (doorwayMade && intersecting.Length == 0)
                    {
                        CreateVerticalDoorway(new Vector3(0, 0, -1));
                        doorwayMade = false;
                    }
                }
            }
            currentPos += Vector3.forward;
        }
    }*/