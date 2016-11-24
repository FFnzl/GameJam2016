using UnityEngine;
using System.Collections;

public class VacuumRumble : MonoBehaviour {
	[SerializeField]
	private float _minRumbleForce;

	[SerializeField]
	private float _maxRumbleForce;

	[SerializeField]
	private float _minRumbleDelay;

	[SerializeField]
	private float _maxRumbleDelay;

	private Rigidbody2D _rigidbody;
	private float _rumbleTimer;
	private Plug _plug;
	private bool _sucking;

	private void Start () {
		_rigidbody = GetComponent<Rigidbody2D>();
		_plug = FindObjectOfType<Plug>();
		_rumbleTimer = 0.0f;
	}

	private void Update () {
		_sucking = _rumbleTimer - Time.time <= 0.0f && _plug.Connected;
		
		if (_sucking) {
			_rumbleTimer = Random.Range(_minRumbleDelay, _maxRumbleDelay) + Time.time;
		}
	}

	private void FixedUpdate () {
		if (_sucking) {
			_rigidbody.AddForce(Random.insideUnitCircle * Random.Range(_minRumbleForce, _maxRumbleForce));
		}
		
	}
}
