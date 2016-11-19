using UnityEngine;
using System.Collections;

public class RoomGenerator : MonoBehaviour {

    public GameObject[] oneEntryRooms;
    public GameObject[] twoEntryRoomsL;
    public GameObject[] twoEntryRoomsD;
    public GameObject[] threeEntryRooms;
    public GameObject[] fourEntryRooms;

    public int numberOfRooms;



	// Use this for initialization
	void Start () {
        GenerateRooms();
	}

    private int countRooms(bool[,] grid, int x, int y)
    {
        return (grid[x, y - 1] ? 1 : 0) +
               (grid[x, y + 1] ? 1 : 0) +
               (grid[x - 1, y] ? 1 : 0) +
               (grid[x + 1, y] ? 1 : 0);
    }
    private bool isDiagonal(bool[,] grid, int x, int y)
    {
        return (grid[x, y - 1] && grid[x, y + 1]) || (grid[x + 1, y] && grid[x - 1, y]);
    }

    private float diagRotation(bool[,] grid, int x,int y)
    {
        return ((grid[x, y - 1] && grid[x, y + 1]) ? 0 : 90);
    }
    private float lRotation(bool[,] grid, int x, int y)
    {
        if ((grid[x, y + 1] && grid[x + 1, y])) return 0;
        else if ((grid[x, y + 1] && grid[x - 1, y])) return 90;
        else if ((grid[x, y - 1] && grid[x - 1, y])) return 180;
        else return 270;
    }
    private float tRotation(bool[,] grid, int x, int y)
    {
        float rotation = diagRotation(grid, x, y) > 0 ? 0 : 90;
        if (rotation > 0) rotation += grid[x + 1, y] ? 180 : 0;
        else rotation += grid[x, y - 1] ? 180 : 0;
        return rotation;
    }
    private float oRotation(bool[,] grid, int x, int y)
    {
        return grid[x - 1, y] ? 90 : grid[x, y - 1] ? 180 : grid[x + 1, y] ? 270 : 0;
    }

    void GenerateRooms()
    {
        int s = (numberOfRooms * 2) + 1;
        bool[,] grid = new bool[s, s];

        Vector2 lr = new Vector2(numberOfRooms + 1, numberOfRooms + 1);
        grid[(int)lr.x, (int)lr.y] = true;

        int reqRooms = numberOfRooms;

        while(reqRooms > 0)
        {
            int next = Random.Range(0, 4);
            bool probe = true;

            int tmpNext = next;
           
            while (probe)
            {
                Vector2 tr = lr;

                switch (tmpNext)
                {
                    //NSEW
                    case 0:
                        tr = new Vector2(lr.x, lr.y - 1);
                        break;
                    case 1:
                        tr = new Vector2(lr.x, lr.y + 1);
                        break;
                    case 2:
                        tr = new Vector2(lr.x + 1, lr.y);
                        break;
                    case 3:
                        tr = new Vector2(lr.x - 1, lr.y);
                        break;
                }

                if (grid[(int)tr.x, (int)tr.y]) tmpNext = (tmpNext + 1) % 4;
                else
                {
                    lr = tr;
                    probe = false;
                }
                if(tmpNext == next)
                {
                    lr = tr;
                    probe = false;
                }
            }
            
            grid[(int)lr.x, (int)lr.y] = true;
            
            reqRooms--;
        }

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                if(grid[x,y])
                {

                    float rotation = 0;

                    GameObject room = null;

                    switch(countRooms(grid, x, y))
                    {
                        case 1:
                            rotation = oRotation(grid, x, y);
                            room = oneEntryRooms[Random.Range(0, oneEntryRooms.Length)];
                            break;
                        case 2:
                            if (isDiagonal(grid, x, y))
                            {
                                rotation = diagRotation(grid, x, y);
                                room = twoEntryRoomsD[Random.Range(0, twoEntryRoomsD.Length)];
                            }
                            else {
                                rotation = lRotation(grid, x, y);
                                room = twoEntryRoomsL[Random.Range(0, twoEntryRoomsL.Length)];
                            }
                            break;
                        case 3:
                            rotation = tRotation(grid, x, y);
                            room = threeEntryRooms[Random.Range(0, threeEntryRooms.Length)];
                            break;
                        case 4:
                            room = fourEntryRooms[Random.Range(0, fourEntryRooms.Length)];
                            break;
                    }

                    GameObject o = Instantiate(room) as GameObject;
                    o.transform.localPosition = new Vector3(x - (numberOfRooms + 1), y - (numberOfRooms + 1));
                    o.transform.Rotate(new Vector3(0,0,rotation));
                    o.transform.parent = transform;
                }
            }
        }

    }
}
