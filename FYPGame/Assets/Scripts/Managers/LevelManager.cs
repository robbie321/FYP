﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour {
    [SerializeField]
    private Transform map;
    //Array to generate more layers on the map eg enemies, trees ect.
    [SerializeField]
    private Texture2D[] mapData;
    //Map Element can be any tile in the world
    [SerializeField]
    private MapElement[] mapElements;
    // This tile is used for measuring the distance between tiles
    [SerializeField]
    private Sprite defaultTile;
  
    // The position of the bottom left corner of the screen
    private Vector3 WorldStartPos
    {
        get
        {
            return Camera.main.ScreenToViewportPoint(new Vector3(0, 0));
        }
    }
	// Use this for initialization
	void Start () {
        GenerateMap();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void GenerateMap()
    {
        int height = mapData[0].height;
        int width = mapData[0].width;

        for (int i = 0; i < mapData.Length; i++)//Looks through all our map layers
        {
            for (int x = 0; x < mapData[i].width; x++) //Runs through all pixels on the layer [x]
            {
                for (int y = 0; y < mapData[i].height; y++)  //[y]
                {
                    Color c = mapData[i].GetPixel(x, y); //Gets the color of the current pixel

                    //Checks if we have a tile that suits the color of the pixel on the map
                    MapElement newElement = Array.Find(mapElements, e => e.MyColor == c);

                    if (newElement != null) //If we found an element with the correct color
                    {
                        //Calculate x and y position of the tile
                        //            bottom left corner    x size of tile width
                        float xPos = WorldStartPos.x + (defaultTile.bounds.size.x * x);
                        float yPos = WorldStartPos.y + (defaultTile.bounds.size.y * y);

                        //Create the tile
                        GameObject go = Instantiate(newElement.MyElementPrefab);

                        //Set the tile's position
                        //go.transform.position = new Vector2(xPos, yPos);
                        go.transform.position = new Vector2(xPos,yPos);
                       /* if (newElement.MyTileTag == "Water")
                        {
                            waterTiles.Add(new Point(x, y), go);
                        }*/
                        //Checks if we are placing a tree
                        if (newElement.MyTileTag == "Tree")
                        {
                            //If we are placing a tree then we need to manage the sort order so the trunks dont overlap
                            go.GetComponent<SpriteRenderer>().sortingOrder = height * 2 - y * 2;
                        }
                        
                        //Make the tile a child of map
                        go.transform.parent = map;

                    }

                }
            }
        }

    //    CheckWater();
    }
}
[Serializable]
public class MapElement
{
    [SerializeField]
    private string tileTag;
    [SerializeField]
    private Color color;
    [SerializeField]
    private GameObject elementPrefab;
    public GameObject MyElementPrefab
    {
        get
        {
            return elementPrefab;
        }
    }
    public Color MyColor
    {
        get
        {
            return color;
        }
    }

    public string myTileTag
    {
        get
        {
            return tileTag;
        }
    }
    public string MyTileTag
    {
        get
        {
            return tileTag;
        }
    }
}
