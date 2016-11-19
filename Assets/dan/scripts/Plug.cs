using UnityEngine;
using System.Collections;

public class Plug : MonoBehaviour {
	public Transform CablePosition;

	public DistanceJoint2D DistanceJoint;
	public HingeJoint2D HingeJoint;

	public Rigidbody2D Body;
	public bool Connected;


	private Socket _currentSocket;
	private bool _onSocket;
	private Socket _touchingSocket;
	private VacuumSounds _sounds;

	private void Start () {
		Body = GetComponent<Rigidbody2D>();

		DistanceJoint = GetComponent<DistanceJoint2D>();
		HingeJoint = GetComponent<HingeJoint2D>();

		_sounds = FindObjectOfType<VacuumSounds>();
	}


	public void PickUp () {
		if (Connected) {
			_currentSocket.Disconnect();
		}
	}

	public void Drop () {
		if (_onSocket) {
			connect();
		}
	}

	private void connect () {
		_touchingSocket.ConnectPlug(this);
		_currentSocket = _touchingSocket;
		Connected = true;

		_sounds.ConnectedPlug();
	}

	public void Disconnect () {
		_currentSocket = null;
		Connected = false;

		_sounds.DisconnectedPlug();
	}

	private void OnTriggerEnter2D (Collider2D pOther) {
		if (pOther.tag == "Socket") {
			_onSocket = true;
			_touchingSocket = pOther.GetComponent<Socket>();
		}
	}

	private void OnTriggerExit2D (Collider2D pOther) {
		if (pOther.tag == "Socket") {
			_onSocket = false;
			_touchingSocket = null;
		}
	}
}
