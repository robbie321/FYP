using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Tilemaps;

public class SceneSetUpManager : MonoBehaviour {

    public GameObject[] enemies;                                 
    public GameObject[] potions;

    private Transform sceneHolder;                                  //A variable to store a reference to the transform of our Board object.
    private List<Vector3> gridPositions = new List<Vector3>();

    /// <summary>
    /// A reference to the ground tilemap
    /// </summary>
    [SerializeField]
    private Tilemap tilemap;

    //void InitialiseList()
    //{
    //    tilemap = transform.GetComponentInParent<Tilemap>();
    //    //for(int i = tilemap.cellBounds.xMin; i <tilemap.cellBounds.xMax; i++)
    //    //{
    //    //    for(int j = tilemap.cellBounds.yMin; j < tilemap.cellBounds.yMax; j++)
    //    //    {
    //    //        gridPositions.Add(new Vector3(i, j, 0f));
    //    //    }
    //    //}
    //    foreach(Vector3Int i in tilemap.cellBounds.allPositionsWithin)
    //    {
    //        gridPositions.Add(i);
    //    }
       
    //    ////Calculates the min and max postion
    //    //Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
    //    //Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);
    //    //gridPositions.Add(new Vector3(minTile, maxTile, 0f));
    //}

    //Vector3 RandomPosition()
    //{
    //    //Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
    //    int randomIndex = Random.Range(0, gridPositions.Count);

    //    //Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
    //    Vector3 randomPosition = gridPositions[randomIndex];

    //    //Remove the entry at randomIndex from the list so that it can't be re-used.
    //    gridPositions.RemoveAt(randomIndex);

    //    //Return the randomly selected Vector3 position.
    //    return randomPosition;
    //}

    ////LayoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create.
    //void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    //{
    //    //Choose a random number of objects to instantiate within the minimum and maximum limits
    //    int objectCount = Random.Range(minimum, maximum + 1);

    //    //Instantiate objects until the randomly chosen limit objectCount is reached
    //    for (int i = 0; i < objectCount; i++)
    //    {
    //        //Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
    //        Vector3 randomPosition = RandomPosition();

    //        //Choose a random tile from tileArray and assign it to tileChoice
    //        GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

    //        //Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
    //        Instantiate(tileChoice, randomPosition, Quaternion.identity);
    //    }
    //}

    //public void SetupScene(int level)
    //{
    //    InitialiseList();
    //    //Determine number of enemies based on current level number, based on a logarithmic progression
    //    int enemyCount = (int)Mathf.Log(level, 2f);
    //    int potionCount = (int)Mathf.Log(level, 2f);

    //    //Instantiate a random number of enemies based on minimum and maximum, at randomized positions.
    //    LayoutObjectAtRandom(enemies, enemyCount, enemyCount);
    //    LayoutObjectAtRandom(potions, potionCount, potionCount);

    //}

}
