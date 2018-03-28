using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    // The camera's target in our case it s the player
    private Transform target;
    // The minimum and maximum value of the camera
    private float xMax, xMin, yMin, yMax;
    // A reference to the ground tilemap
    [SerializeField]
    private Tilemap tilemap;
    // A reference to the player
    private Player player;

    // Use this for initialization
    void Start()
    {
        //Creates a reference to the target
        target = GameObject.FindGameObjectWithTag("Player").transform;

        //Creates a reference to the player's script
        player = target.GetComponent<Player>();

        //Calculates the min and max postion
        Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
        Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);

        //Sets the limits of the camera
        SetLimits(minTile, maxTile);

        //Sets the limits of the player
        player.SetLimits(minTile, maxTile);

    }

    private void LateUpdate()
    {
        //Makes sure the camera doesn't go further than our world
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), -10);
    }

    // Sets the cameras limits, this is used to make sure it can't go over the edge of the main tilemap
    private void SetLimits(Vector3 minTile, Vector3 maxTile)
    {
        Camera cam = Camera.main;

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        xMin = minTile.x + width / 2;
        xMax = maxTile.x - width / 2;

        yMin = minTile.y + height / 2;
        yMax = maxTile.y - height / 2;
    }
}
