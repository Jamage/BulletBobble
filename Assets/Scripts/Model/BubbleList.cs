using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleList : MonoBehaviour
{
    public Transform startPosition;
    //public List<List<Bubble>> bubbleList;
    public int baseWidth;
    public int baseHeight;
    public List<List<Bubble>> bubbleList;
    //public Bubble GenBubble { get { return new Bubble(); } set { GenBubble = value; } }

    private void Awake()
    {
        bubbleList = new List<List<Bubble>>();
        GenerateList();
        PositionBubbles();
    }

    void Start()
    {

    }

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
            bubbleList.Add(new List<Bubble>());

            for (int y = 0; y < baseHeight; y++)
            {
                Bubble bubble = Bubble.NewBubble();
                bubbleList[x].Add(bubble);
                bubbleList[x][y].transform.SetParent(this.transform);
                //Destroy(tempBub);
            }
        }
    }

    private void PositionBubbles()
    {
        for (int x = 0; x < bubbleList.Count; x++)
        {
            for (int y = 0; y < bubbleList[x].Count; y++)
            {
                //GameObject tempGO = Instantiate(Resources.Load(bubbleList[y][x].objectName), new Vector3(this.transform.position.x + x, this.transform.position.y - y, 0), Quaternion.identity) as GameObject;
                float xMod = x;
                if (y % 2 == 1)
                    xMod = x + .5f;

                float yMod = 7f / 8f;

                bubbleList[x][y].transform.position = new Vector3(this.transform.position.x + xMod, this.transform.position.y - (y * yMod), 0);

            }
        }
    }

    bool RowHasBubbles(int y)
    {
        for(int x = 0; x < bubbleList[x].Count; x++)
        {
            if (bubbleList[x][y] != null)
                return true;
        }

        return false;
    }

    bool HasBubble(int x, int y)
    {
        if (bubbleList[x][y] != null)
            return true;
        else
            return false;
    }

    //Configuration of the Grid needs to change with every added line... The positions move left/right currently depending on row
    void AddTopRow()
    {
        for (int x = 0; x < baseWidth; x++)
        {
            bubbleList[x].Add(bubbleList[x][bubbleList[x].Count - 1]);

            for (int y = bubbleList[x].Count - 2; y >= 0; y--)
            {
                bubbleList[x][y + 1] = bubbleList[x][y];
            }
        }

        AddRow(0);
        PositionBubbles();
    }

    void AddRow(int rowNum)
    {
        for (int x = 0; x < baseWidth; x++)
        {
            bubbleList[x][rowNum] = Bubble.NewBubble();
            bubbleList[x][rowNum].transform.parent = this.transform;
        }
    }

    void AddDiag() //This is probably a bad idea for a method LOL
    {

    }

    void AddBubble(int row, int column, Bubble bubble)
    {
        bubbleList[row][column] = bubble;
    }

    void AddBubble(int row, int column)
    {
        bubbleList[row][column] = ((GameObject)Instantiate(Resources.Load("Bubble"))).AddComponent<Bubble>();
    }

    void ChangeColor(Bubble.BubbleColor oldColor, Bubble.BubbleColor newColor)
    {
        for (int x = 0; x < bubbleList.Count; x++)
        {
            for (int y = 0; y < bubbleList[x].Count; y++)
            {
                if (bubbleList[x][y].GetComponent<Bubble>().Color== oldColor)
                    bubbleList[x][y].GetComponent<Bubble>().Color = newColor;
            }
        }
    }

    void SwapPositions(Vector2 bubblePosOne, Vector2 bubblePosTwo)
    {
        Bubble refOne = bubbleList[(int)bubblePosOne.x][(int)bubblePosOne.y];
        Bubble refTwo = bubbleList[(int)bubblePosTwo.x][(int)bubblePosTwo.y];

        bubbleList[(int)bubblePosTwo.x][(int)bubblePosTwo.y] = refOne;
        bubbleList[(int)bubblePosOne.x][(int)bubblePosOne.y] = refTwo;
    }

}
