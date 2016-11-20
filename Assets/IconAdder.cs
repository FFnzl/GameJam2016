using UnityEngine;
using System.Collections;

public class IconAdder : MonoBehaviour {

    public GameObject IconPrefab;

	// Use this for initialization
	void Start () {
       GameObject o = Instantiate(IconPrefab, transform.position, Quaternion.identity) as GameObject;
        //o.transform.parent = transform;

	}

}
