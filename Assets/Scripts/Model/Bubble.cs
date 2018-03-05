using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject bubbleObject;
    public Transform pos;
    public Material bubbleMaterial;
    public string objectName;

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
                    gameObject.name = objectName;
                    bubbleObject.GetComponent<Renderer>().material = (Material)Resources.Load("BlackBubbleMaterial");
                    bubbleMaterial = bubbleObject.GetComponent<Renderer>().material;
                    //view.GetComponent<Renderer>().material.color = new UnityEngine.Color(0, 0, 0, 255f);
                    break;
                case BubbleColor.Blue:
                    objectName = "BlueBubble";
                    gameObject.name = objectName;
                    bubbleObject.GetComponent<Renderer>().material = (Material)Resources.Load("BlueBubbleMaterial");
                    bubbleMaterial = bubbleObject.GetComponent<Renderer>().material;
                    //view.GetComponent<Renderer>().material.color = new UnityEngine.Color(0, 0, 255f, 255f);
                    break;
                case BubbleColor.Green:
                    objectName = "GreenBubble";
                    gameObject.name = objectName;
                    bubbleObject.GetComponent<Renderer>().material = (Material)Resources.Load("GreenBubbleMaterial");
                    bubbleMaterial = bubbleObject.GetComponent<Renderer>().material;
                    //view.GetComponent<Renderer>().material.color = new UnityEngine.Color(0, 255f, 0, 255f);
                    break;
                case BubbleColor.Red:
                    objectName = "RedBubble";
                    gameObject.name = objectName;
                    bubbleObject.GetComponent<Renderer>().material = (Material)Resources.Load("RedBubbleMaterial");
                    bubbleMaterial = bubbleObject.GetComponent<Renderer>().material;
                    //view.GetComponent<Renderer>().material.color = new UnityEngine.Color(255f, 0, 0, 255f);
                    break;
                case BubbleColor.White:
                    objectName = "WhiteBubble";
                    gameObject.name = objectName;
                    bubbleObject.GetComponent<Renderer>().material = (Material)Resources.Load("WhiteBubbleMaterial");
                    bubbleMaterial = bubbleObject.GetComponent<Renderer>().material;
                    //view.GetComponent<Renderer>().material.color = new UnityEngine.Color(255f, 255f, 255f, 255f);
                    break;
            };
        }
    }

    void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        bubbleObject = this.gameObject;
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
