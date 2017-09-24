using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustVisionController : MonoBehaviour {

	private SpriteMask sm;

	// Use this for initialization
	void Start () {
		sm = GetComponent<SpriteMask> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("DustVision")) {
			sm.enabled = true;
		} else {
			sm.enabled = false;	
		}
	}
}
