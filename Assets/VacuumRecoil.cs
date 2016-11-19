using UnityEngine;
using System.Collections;

public class VacuumRecoil : MonoBehaviour {
	[SerializeField]
	private float _recoilForce;

	private Plug _plug;
	private Rigidbody2D _rigidbody;
	private bool _sucking;

	private void Start () {
		_rigidbody = GetComponent<Rigidbody2D>();
		_plug = FindObjectOfType<Plug>();
	}

	private void Update () {
		_sucking = Input.GetMouseButton(0) && _plug.Connected;
	}

	private void FixedUpdate() {
		if (_sucking) {
			_rigidbody.AddRelativeForce(new Vector2(_recoilForce, 0.0f));
		}
	}
}
