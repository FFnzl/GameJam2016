using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour {
	[SerializeField]
	private float _moveSpeed;

	[SerializeField]
	private float _accelaration;

	private Rigidbody2D _rigidBody;
	private Camera _cam;

	private void Start () {
		_rigidBody = GetComponent<Rigidbody2D>();
		_cam = Camera.main;
	}

	private void FixedUpdate() {
		//_rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _moveSpeed * Time.deltaTime;

		if (_rigidBody.velocity.magnitude < _moveSpeed) {
			_rigidBody.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * _accelaration);
		}
	}

	private void Update () {
		//if (FindObjectOfType<ControllerManager>().UsingController) {
		if(PlayerPrefsX.GetBool("controller")) {
			float x = Input.GetAxis("JoyHorizontal");
			float y = Input.GetAxis("JoyVertical");

			if (x != 0.0f || y != 0.0f) {
				_rigidBody.rotation = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
			}
		} else {
			float camDis = _cam.transform.position.y - transform.position.y;
			Vector3 mouse = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));
			float angleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
			_rigidBody.rotation = angleRad * Mathf.Rad2Deg;
		}
	}
}
