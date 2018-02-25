using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IComparable<Obstacle>
{
    //obstacles spriterenderer 
    public SpriteRenderer MySpriteRenderer { get; set; }
    //Color to use the the obstacle isn't faded
    private Color defaultColor;
    //Color to use the the obstacle is faded out
    private Color fadedColor;
    //Compare to, that is used for sorting the obstacles, so that we can pick the one with the lowest sortorder
    public int CompareTo(Obstacle other)
    {
        if (MySpriteRenderer.sortingOrder > other.MySpriteRenderer.sortingOrder)
        {
            return 1; //If this obstacles has a higher sortorder 
        }
        else if (MySpriteRenderer.sortingOrder < other.MySpriteRenderer.sortingOrder)
        {
            return -1; //If this obstacles has a lower sortorder 
        }

        return 0; //If both obstacles ha an equal sortorder
    }

    // Use this for initialization
    void Start()
    {
        //Creates a reference to the spriterendere
        MySpriteRenderer = GetComponent<SpriteRenderer>();

        //Creates the colors
        defaultColor = MySpriteRenderer.color;
        fadedColor = defaultColor;
        fadedColor.a = 0.85f;
    }

    //Fades out the obstacle
    public void FadeOut()
    {
        MySpriteRenderer.color = fadedColor;
    }

    //Fades in the obstacle
    public void FadeIn()
    {
        MySpriteRenderer.color = defaultColor;
    }

}
