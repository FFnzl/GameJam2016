using UnityEngine;
using System.Collections;

public class VacuumRecoil : MonoBehaviour {
	[SerializeField]
	private float _recoilForce;

	private Plug _plug;
	private Rigidbody2D _rigidbody;

	private void Start () {
		_rigidbody = GetComponent<Rigidbody2D>();
		_plug = FindObjectOfType<Plug>();
	}

	private void FixedUpdate() {
		if (_plug.Connected) {
			_rigidbody.AddRelativeForce(new Vector2(_recoilForce, 0.0f));
		}
	}
}
