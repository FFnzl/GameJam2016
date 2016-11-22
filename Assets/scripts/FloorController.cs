using UnityEngine;
using System.Collections;
using System.Text;

public class FloorController : MonoBehaviour {





    // Use this for initialization
    void Start() {

        FloorComponents fc = GameObject.FindGameObjectWithTag("FloorManager").GetComponent<FloorComponents>();
        Room r = GetComponent<Room>();


        string randPattern = fc.RandomPattern;

        string[] pattern = randPattern.Split(',');

        for (int i = 0; i < pattern.Length; i++)
        {
            GameObject o = Instantiate(fc.floorPrefab) as GameObject;
            o.transform.parent = transform;
            o.transform.localPosition = new Vector3((((i % 10) - 5) * 0.1f) + 0.05f, (((i / 10) - 5) * -0.1f) - 0.05f);
            o.transform.localScale = new Vector3(1, 1);
            o.GetComponent<SpriteRenderer>().sprite = fc.floors[int.Parse(pattern[i])];

            r.tiles.Add(o);
        }
	}
}
