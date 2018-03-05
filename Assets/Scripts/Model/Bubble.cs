using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    //public GameObject bubbleObject;
    public Transform pos;
    public string objectName;
    public static int runNum = 0;

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

    public BubbleColor color
    {
        get { return GetRandomEnum<BubbleColor>(); } 
        set
        {
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
        Debug.Log("Awake: " + runNum++);
        Setup();
    }

    private void Setup()
    {
        //this.gameObject = Instantiate(Resources.Load("Bubble") as GameObject);
        color = GetRandomEnum<Bubble.BubbleColor>();
    }

    //public Bubble()
    //{
    //    color = GetRandomEnum<Bubble.Color>();
    //}

    public T GetRandomEnum<T>()
    {
        Array values = Enum.GetValues(typeof(T));
        int num = (int)UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(num);
    }

    //public Bubble(Color bubbleColor)
    //{
    //    color = bubbleColor;
    //}

    //private void Awake()
    //{
    //    view = this.gameObject;
    //}

    //void Start()
    //{
    //Bubble bubble = new Bubble();
    //Debug.Log("Bubble color: " + bubble.color.ToString());
    //}


    public void ChangeColor(BubbleColor newColor)
    {
        color = newColor;
    }

    public void ChangeColor()
    {
        color = GetRandomEnum<Bubble.BubbleColor>();
    }
}
