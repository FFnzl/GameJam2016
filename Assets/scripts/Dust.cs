using UnityEngine;
using System.Collections;

public class Dust : MonoBehaviour {
	[SerializeField]
	private float _maxVelocity;

	private SuckDust _suckDust;
	private Rigidbody2D _rigidbody;

	private void Start () {
		_suckDust = FindObjectOfType<SuckDust>();
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate () {
		if (_rigidbody.velocity.magnitude > _maxVelocity) {
			_rigidbody.velocity = _rigidbody.velocity.normalized * _maxVelocity;
		}
	}

	private void OnDestroy () {
		_suckDust.RemoveDust(gameObject);
	}
}
