using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    //public GameObject bubbleObject;
    public Transform pos;
    public string objectName;
    private BubbleColor color;

    public enum BubbleColor
    {
        Blue,
        Red,
        Green,
        White,
        Black
    }

    public enum Special
    {
        None,
        Bomb,
        ColorClear
    }
    
    public BubbleColor Color
    {
        get { return color; } 
        set
        {
            color = value;

            switch (value)
            {
                case BubbleColor.Black:
                    objectName = "BlackBubble";
                    this.name = objectName;
                    this.GetComponent<Renderer>().material = (Material)Resources.Load("BlackBubbleMaterial");
                    break;
                case BubbleColor.Blue:
                    objectName = "BlueBubble";
                    this.name = objectName;
                    this.GetComponent<Renderer>().material = (Material)Resources.Load("BlueBubbleMaterial");
                    break;
                case BubbleColor.Green:
                    objectName = "GreenBubble";
                    this.name = objectName;
                    this.GetComponent<Renderer>().material = (Material)Resources.Load("GreenBubbleMaterial");
                    break;
                case BubbleColor.Red:
                    objectName = "RedBubble";
                    this.name = objectName;
                    this.GetComponent<Renderer>().material = (Material)Resources.Load("RedBubbleMaterial");
                    break;
                case BubbleColor.White:
                    objectName = "WhiteBubble";
                    this.name = objectName;
                    this.GetComponent<Renderer>().material = (Material)Resources.Load("WhiteBubbleMaterial");
                    break;
            };
        }
    }

    public static Bubble NewBubble()
    {
        return ((GameObject)Instantiate(Resources.Load("Bubble"))).AddComponent<Bubble>();
    }

    void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        Color = Utility.GetRandomEnum<Bubble.BubbleColor>();
    }

    public void ChangeColor(BubbleColor newColor)
    {
        Color = newColor;
    }

    public void RandomizeColor()
    {
        Color = Utility.GetRandomEnum<Bubble.BubbleColor>();
    }
}
