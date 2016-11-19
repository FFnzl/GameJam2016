using UnityEngine;
using System.Collections;

public class PlugPickup : MonoBehaviour {
	[SerializeField]
	private float _plugPickupDistance = 1.0f;

	private bool _carryingPlug;

	private Plug _plug;

	private void Start () {
		_plug = FindObjectOfType<Plug>();
	}

	private void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			if (Vector2.Distance(transform.position, _plug.transform.position) <= _plugPickupDistance && !_carryingPlug) {
				_plug.PickUp();
				_carryingPlug = true;
			} else if (_carryingPlug) {
				_plug.Drop();
				_carryingPlug = false;
			}
		}
	}

	private void FixedUpdate () {
		if (_carryingPlug) {
			//_plug.Body.position = transform.position;
			_plug.Body.MovePosition(transform.position);
		}
	}
}
