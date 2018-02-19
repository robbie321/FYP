using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour, IComparable<Obstacle>
{
    // The obstacles spriterenderer 
    public SpriteRenderer spriteRenderer { get; set; }
    // Color to use the the obstacle isn't faded
    private Color defaultColor;
    // Color to use the the obstacle is faded out
    private Color fadedColor;
    // Compare to, that is used for sorting the obstacles, so that we can pick the on with the lowest sortorder
    public int CompareTo(Obstacle other)
    {
        if (spriteRenderer.sortingOrder > other.spriteRenderer.sortingOrder)
        {
            return 1; //If this obstacles has a higher sortorder 
        }
        else if (spriteRenderer.sortingOrder < other.spriteRenderer.sortingOrder)
        {
            return -1; //If this obstacles has a lower sortorder 
        }

        return 0; //If both obstacles ha an equal sortorder
    }

    // Use this for initialization
    void Start()
    {
        //Creates a reference to the spriterendere
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Creates the colors
        defaultColor = spriteRenderer.color;
        fadedColor = defaultColor;
        fadedColor.a = 0.7f;
    }

    // Fades out the obstacle
    public void FadeOut()
    {
        spriteRenderer.color = fadedColor;
    }

    // Fades in the obstacle
    public void FadeIn()
    {
        spriteRenderer.color = defaultColor;
    }

}
