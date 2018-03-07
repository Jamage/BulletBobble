using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleList : MonoBehaviour
{
    public Transform startPosition;
    public int baseWidth;
    public int baseHeight;
    public List<List<Bubble>> bubbleList;
    bool alignedLeft = false;

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

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                Bubble bubble = hit.collider.GetComponent<Bubble>();
                Vector2 position = FindPosition(bubble);
                PopCluster(bubble, position);
            }
            
        }
    }

    private void PopCluster(Bubble bubble, Vector2 position)
    {
        List<Bubble> cluster = StartFindCluster(bubble, position);
    }

    public enum LastDirection
    {
        None,
        Left,
        Right,
        Up,
        Down
    }

    //Create recursive method sequence
    //Has START, which runs Left, Right, Up, Down searches if possible
    //If bubble found, run Start with it.
    //Need safeguards to ensure that the same bubble isn't being covered. Store list of positions to avoid? Pass cluster list to check if the object already exists?
    private List<Bubble> StartFindCluster(Bubble bubble, Vector2 position, LastDirection lastDir = LastDirection.None)
    {
        List<Bubble> cluster = new List<Bubble>();
        int x = (int)position.x;
        int y = (int)position.y;

        //right
        if(lastDir != LastDirection.Left)
        if (bubbleList[x + 1][y].Color == bubble.Color)
        {
            cluster.Add(bubbleList[x + 1][y]);
            cluster.AddRange(StartFindCluster(bubbleList[x + 1][y], new Vector2(x + 1, y)));
        }
        //left
        if(lastDir != LastDirection.Right)
        if(bubbleList[x - 1][y].Color == bubble.Color)
        {
            cluster.Add(bubbleList[x - 1][y]);
            cluster.AddRange(StartFindCluster(bubbleList[x - 1][y], new Vector2(x - 1, y)));

        }
        //up
        if(lastDir != LastDirection.Down)
        if(bubbleList[x][y + 1].Color == bubble.Color)
        {
            cluster.Add(bubbleList[x][y + 1]);
            cluster.AddRange(StartFindCluster(bubbleList[x][y + 1], new Vector2(x, y + 1)));
        }
        //down
        if(lastDir != LastDirection.Up)
        if(bubbleList[x][y - 1].Color == bubble.Color)
        {
            cluster.Add(bubbleList[x][y - 1]);
            cluster.AddRange(StartFindCluster(bubbleList[x][y - 1], new Vector2(x, y - 1)));
        }
        return cluster;
    }

    private Vector2 FindPosition(Bubble bubble)
    {
        for (int x = 0; x < bubbleList.Count; x++)
        {
            for (int y = 0; y < bubbleList[x].Count; y++)
            {
                if (bubbleList[x][y] == bubble)
                    return new Vector2(x, y);
            }
        }
        return new Vector2();
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
            }
        }
    }

    private void PositionBubbles()
    {
        float xMod;
        float yMod = 7f / 8f;

        for (int x = 0; x < bubbleList.Count; x++)
        {
            for (int y = 0; y < bubbleList[x].Count; y++)
            {
                int modCheck = y + (alignedLeft == true ? 1 : 0);

                if (modCheck % 2 == 1)
                    xMod = x + .5f;
                else
                    xMod = x;

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
        ToggleAlignment();
        PositionBubbles();
    }

    private void ToggleAlignment()
    {
        if (alignedLeft)
            alignedLeft = false;
        else
            alignedLeft = true;
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
