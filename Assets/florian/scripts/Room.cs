using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {

    public enum RoomType { TYPE_O, TYPE_I, TYPE_L, TYPE_T, TYPE_X }
    public RoomType type;

    public List<GameObject> doors;

    void Start()
    {
        doors = new List<GameObject>();
    }
    
}
