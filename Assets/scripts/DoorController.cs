using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{

	private Rigidbody2D _body;

	[SerializeField]
	private bool _startLocked = false;

	// Use this for initialization
	void Start()
	{
		_body = GetComponent<Rigidbody2D>();
		_body.freezeRotation = _startLocked;
	}

	void Unlock()
	{
		_body.freezeRotation = false;
	}
}
