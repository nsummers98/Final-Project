using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public float columns = 8;
    public float rows = 8;
    public Count wallCount = new Count(5, 9);
    public Count healthCount = new Count(1, 5);
    public GameObject exit;
    public GameObject[] monster;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] healthRunes;
    public GameObject[] collectRunes;
    public GameObject[] outerWallTiles;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitializeList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
                gridPositions.Add(new Vector3(x, y, 0f));
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    if (x == -1 && y == -1)
                        toInstantiate = outerWallTiles[1];
                    else if (x == columns && y == -1)
                        toInstantiate = outerWallTiles[2];
                    else if (x == -1 && y == rows)
                        toInstantiate = outerWallTiles[3];
                    else if (x == columns && y == rows)
                        toInstantiate = outerWallTiles[4];
                    else if (x == -1 || x == columns)
                        toInstantiate = outerWallTiles[5];
                    else
                        toInstantiate = outerWallTiles[0];
                }

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
        InitializeList();
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        LayoutObjectAtRandom(healthRunes, healthCount.minimum, healthCount.maximum);
        LayoutObjectAtRandom(collectRunes, 10, 10);
        //LayoutObjectAtRandom(monster, 1, 1);
        Instantiate(exit, new Vector3(columns - 1.5f, rows + 1f, 0f), Quaternion.identity);
    }
}
