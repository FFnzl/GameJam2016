using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    Rigidbody2D rb;

    public bool startLocked = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = startLocked;
	}
    
    void unlock()
    {
        rb.freezeRotation = false;
    }
}
