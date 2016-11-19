using UnityEngine;
using System.Collections;
using System.Text;

public class FloorController : MonoBehaviour {





    // Use this for initialization
    void Start() {

        FloorComponents fc = GameObject.FindGameObjectWithTag("FloorManager").GetComponent<FloorComponents>();
        
        string randPattern = fc.floorPattern[Random.Range(0, fc.floorPattern.Length)];

        string[] pattern = randPattern.Split(',');

        for (int i = 0; i < pattern.Length; i++)
        {
            GameObject o = Instantiate(fc.floors[int.Parse(pattern[i])]) as GameObject;
            o.transform.parent = transform;
            o.transform.localPosition = new Vector3((((i % 10) - 5) * 0.1f) + 0.05f, (((i / 10) - 5) * -0.1f) - 0.05f);
            o.transform.localScale = new Vector3(1, 1);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
