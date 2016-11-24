using UnityEngine;
using System.Collections;

public class PlugPickup : MonoBehaviour {
	[SerializeField]
	private float _plugPickupDistance = 1.0f;

	private bool _carryingPlug;

	private Plug _plug;
	private ChangeCharacterSprite _sprite;

	[SerializeField]
	private Transform _carryPoint;

	private void Start () {
		_plug = FindObjectOfType<Plug>();
		_sprite = FindObjectOfType<ChangeCharacterSprite>();
	}

	private void Update () {
		if (Input.GetButtonDown("Interact")) {
			if (Vector2.Distance(transform.position, _plug.transform.position) <= _plugPickupDistance && !_carryingPlug) {
				_plug.PickUp();
				_sprite.PickUp();
				_carryingPlug = true;
			} else if (_carryingPlug) {
				_plug.Drop();
				_sprite.Drop();
				_carryingPlug = false;
			}
		}
	}

	private void FixedUpdate () {
		if (_carryingPlug) {
			_plug.Body.MovePosition(_carryPoint.position);
			_plug.Body.MoveRotation(_carryPoint.rotation.eulerAngles.z);
		}
	}
}
