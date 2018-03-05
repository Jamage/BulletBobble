using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGrid : MonoBehaviour
{
    public Transform startPosition;
    public Bubble[,] bubbleGrid;
    public int baseWidth = 9;
    public int baseHeight = 7;
    public List<GameObject> bubblePrefabs;

    private void Awake()
    {
        bubbleGrid = new Bubble[baseWidth, baseHeight];
    }
    
    // Use this for initialization
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateGrid()
    {
        for(int x = 0; x < baseWidth; x++)
        {
            for(int y = 0; y < baseHeight; y++)
            {
                bubbleGrid[x, y] = new Bubble();
            }
        }
    }

    void AddTopRow()
    {
        for(int x = baseWidth; x >= 0; --x)
        {
            for(int y = baseHeight; y >= 0; --y)
            {
                bubbleGrid[x, y + 1] = bubbleGrid[x, y];
            }
        }

        AddRow(0);
    }

    void AddRow(int rowNum)
    {
        for(int x = 0; x < baseWidth; x++)
        {
            bubbleGrid[x, 0] = new Bubble();
        }
    }
    
    void AddDiag()
    {

    }

    //Pushes all touching grid objects out horizontally out & diagonally down
    void AddBubble()
    {

    }

    void PositionBubbles()
    {
        for(int x = 0; x < baseWidth; x++)
        {
            for(int y = 0; y < baseHeight; y++)
            {
                bubbleGrid[x, y].pos.localPosition = new Vector3(x, y, 0);
            }
        }
    }

}
