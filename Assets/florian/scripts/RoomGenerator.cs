using UnityEngine;
using System.Collections;

public class RoomGenerator : MonoBehaviour {

    public GameObject doorPrefab;

    public Vector2 scale = new Vector2(3,3);

    private GameObject[] oneEntryRooms;
	private GameObject[] twoEntryRoomsL;
	private GameObject[] twoEntryRoomsD;
	private GameObject[] threeEntryRooms;
	private GameObject[] fourEntryRooms;

    public int numberOfRooms;

    public GameObject[,] map;

    public bool spawnOutside = false;


	void Awake () {
		oneEntryRooms = Resources.LoadAll<GameObject>("rooms/O");
		twoEntryRoomsL = Resources.LoadAll<GameObject>("rooms/L");
		twoEntryRoomsD = Resources.LoadAll<GameObject>("rooms/I");
		threeEntryRooms = Resources.LoadAll<GameObject>("rooms/T");
		fourEntryRooms = Resources.LoadAll<GameObject>("rooms/X");
	}

	// Use this for initialization
	void Start () {
		GenerateRooms();
	}

    #region Utility 

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

    #endregion

    void GenerateRooms()
    {
        int s = (numberOfRooms * 4);
        bool[,] grid = new bool[s+1, s+1];
        map = new GameObject[s+1, s+1];

        Vector2 lr = new Vector2((s/2), (s/2));
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

                    bool startRoom = x == (s / 2) && y == (s / 2);

                    switch(countRooms(grid, x, y))
                    {
                        case 1:
                            rotation = oRotation(grid, x, y);
                            room = oneEntryRooms[startRoom ? 0 : Random.Range(1, oneEntryRooms.Length)];
                            break;
                        case 2:
                            if (isDiagonal(grid, x, y))
                            {
                                rotation = diagRotation(grid, x, y);
                                room = twoEntryRoomsD[startRoom ? 0 : Random.Range(1, twoEntryRoomsD.Length)];
                            }
                            else {
                                rotation = lRotation(grid, x, y);
                                room = twoEntryRoomsL[startRoom ? 0 : Random.Range(1, twoEntryRoomsL.Length)];
                            }
                            break;
                        case 3:
                            rotation = tRotation(grid, x, y);
                            room = threeEntryRooms[startRoom ? 0 : Random.Range(1, threeEntryRooms.Length)];
                            break;
                        case 4:
                            room = fourEntryRooms[startRoom ? 0 : Random.Range(1, fourEntryRooms.Length)];
                            break;
                    }

                    float locX = x - (s/2);
                    float locY = y - (s/2);
                    GameObject o = null;
                    if (!(spawnOutside && startRoom))
                    {

                        o = Instantiate(room) as GameObject;
                        o.transform.localPosition = new Vector3(locX, locY);
                        o.transform.Rotate(new Vector3(0, 0, rotation));
                        o.transform.parent = transform;

                        if (startRoom) o.GetComponent<RandomDustPlacement>().enabled = false;
                    }

                    GameObject door = null;
                        
                    if (grid[x - 1, y])
                    {
                        door = Instantiate(doorPrefab) as GameObject;
                        door.transform.parent = transform;
                        door.transform.localPosition = new Vector3(-0.5f + locX, 0.1f + locY, 0);
                        door.transform.Rotate(0, 0, -90);
                    }
                    if(o != null) o.GetComponent<Room>().doors.Add(door);
                    if (map[x - 1, y] != null) map[x - 1, y].GetComponent<Room>().doors.Add(door);

                    if (grid[x, y -1])
                    {
                        door = Instantiate(doorPrefab) as GameObject;
                        door.transform.parent = transform;
                        door.transform.localPosition = new Vector3(-0.1f + locX, -0.5f + locY, 0);
                    }
                    if(o != null) o.GetComponent<Room>().doors.Add(door);
                    if (map[x, y - 1] != null) map[x, y - 1].GetComponent<Room>().doors.Add(door);

                    map[x, y] = o;
                    if (o != null && !startRoom) GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>().totalRooms++;
                }
            }
        }
        transform.localScale = new Vector3(scale.x, scale.y);
    }
}
