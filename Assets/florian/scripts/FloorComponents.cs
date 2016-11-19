using UnityEngine;
using System.Collections;

public class FloorComponents : MonoBehaviour {

    public string[] floorPattern;
    public Sprite[] floors;

    public GameObject floorPrefab;

    public Sprite RandomSprite
    {
        get { return floors.Length > 0 ? floors[Random.Range(0, floors.Length)] : null; }
    }

    public string RandomPattern
    {
        get { return floorPattern.Length > 0 ? floorPattern[Random.Range(0, floorPattern.Length)] : null; }
    }

}
