using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleList : MonoBehaviour
{
    public Transform startPosition;
    //public List<List<Bubble>> bubbleList;
    public int baseWidth = 9;
    public int baseHeight = 7;
    public List<List<Bubble>> bubblePrefabs;
    public Bubble GenBubble { get { return new Bubble(); } set { GenBubble = value; } }

    private void Awake()
    {
        bubblePrefabs = new List<List<Bubble>>();
        //bubbleList = new List<List<Bubble>>();
    }

    // Use this for initialization
    void Start()
    {
        GenerateList();
        PositionBubbles();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddTopRow();
        }
    }

    void GenerateList()
    {
        for (int x = 0; x < baseWidth; x++)
        {
            for (int y = 0; y < baseHeight; y++)
            {
                bubblePrefabs.Add(new List<Bubble>());
                Bubble tempBub = new Bubble();
                tempBub.transform.parent = this.transform;
                bubblePrefabs[x].Add(new Bubble());
            }
        }
    }

    private void PositionBubbles()
    {
        for (int x = 0; x < baseWidth; x++)
        {
            for (int y = 0; y < baseHeight; y++)
            {
                //GameObject tempGO = Instantiate(Resources.Load(bubbleList[y][x].objectName), new Vector3(this.transform.position.x + x, this.transform.position.y - y, 0), Quaternion.identity) as GameObject;
                float xMod = x;
                if (y % 2 == 1)
                    xMod = x + .5f;

                float yMod = 7f / 8f;

                bubblePrefabs[x][y].transform.position = new Vector3(this.transform.position.x + xMod, this.transform.position.y - (y * yMod), 0);

            }
        }
    }

    bool RowHasBubbles(int row)
    {
        for(int x = 0; x < bubblePrefabs[x].Count; x++)
        {
            if (bubblePrefabs[x][row] != null)
                return true;
        }

        return false;
    }

    void AddTopRow()
    {
        bubblePrefabs.Add(new List<Bubble>());

        for (int x = baseWidth; x >= 0; --x)
        {
            for (int y = baseHeight; y >= 0; --y)
            {
                bubblePrefabs[x + 1] = bubblePrefabs[x];
            }
        }

        AddRow(0);
    }

    void AddRow(int rowNum)
    {
        for (int x = 0; x < baseWidth; x++)
        {
            bubblePrefabs[0].Add(new Bubble());
        }
    }

    void AddDiag()
    {

    }

    void AddBubble(int row, int column, Bubble bubble)
    {
        bubblePrefabs[row][column] = bubble;
    }

    void AddBubble(int row, int column)
    {
        bubblePrefabs[row][column] = GenBubble;
    }

    //void PositionBubbles()
    //{
    //    for (int x = 0; x < baseWidth; x++)
    //    {
    //        for (int y = 0; y < baseHeight; y++)
    //        {
    //            if (x % 2 == 1)
    //                bubbleList[x][y].pos.localPosition = new Vector3(x, y, 0);
    //            else
    //                bubbleList[x][y].pos.localPosition = new Vector3(x + 1, y, 0);
    //        }
    //    }
    //}

    void ChangeColor(Bubble.BubbleColor oldColor, Bubble.BubbleColor newColor)
    {
        for (int x = 0; x < bubblePrefabs.Count; x++)
        {
            for (int y = 0; y < bubblePrefabs[x].Count; y++)
            {
                if (bubblePrefabs[x][y].GetComponent<Bubble>().color== oldColor)
                    bubblePrefabs[x][y].GetComponent<Bubble>().color = newColor;
            }
        }
    }

    void SwapPositions(Vector2 bubblePosOne, Vector2 bubblePosTwo)
    {
        Bubble refOne = bubblePrefabs[(int)bubblePosOne.x][(int)bubblePosOne.y];
        Bubble refTwo = bubblePrefabs[(int)bubblePosTwo.x][(int)bubblePosTwo.y];

        bubblePrefabs[(int)bubblePosTwo.x][(int)bubblePosTwo.y] = refOne;
        bubblePrefabs[(int)bubblePosOne.x][(int)bubblePosOne.y] = refTwo;
    }

}
