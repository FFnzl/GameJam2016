using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * 100);
    }
	
	// Update is called once per frame
	void Update () {
    }
}
