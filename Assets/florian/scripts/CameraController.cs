using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(player.position.x, player.position.y, -2);
	}
}
