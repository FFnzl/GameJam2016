using UnityEngine;
using System.Collections;

public class DoorSound : MonoBehaviour {
	private AudioSource _source;
	private Rigidbody2D _body;

	[SerializeField]
	private float _pitchDelta;

	[SerializeField]
	private float _minDelay;

	[SerializeField]
	private float _triggerVelocity;

	private float _timer;

	private void Start () {
		_source = GetComponent<AudioSource>();
		_body = GetComponent<Rigidbody2D>();
	}

	private void Update () {
		if (_timer - Time.time <= 0.0f && _body.velocity.magnitude > _triggerVelocity) {
			_timer = Time.time + _minDelay;
			_source.pitch = 1 + Random.Range(-_pitchDelta, _pitchDelta);
			_source.Play();
		}
	}
}
