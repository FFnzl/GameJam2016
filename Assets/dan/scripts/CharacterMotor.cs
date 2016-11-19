using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour {
	[SerializeField]
	private float _moveSpeed;

	[SerializeField]
	private float _accelaration;

	private Rigidbody2D _rigidBody;

	private void Start () {
		_rigidBody = GetComponent<Rigidbody2D>();
	}

	private void Update () {
		//_rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _moveSpeed * Time.deltaTime;

		if (_rigidBody.velocity.magnitude < _moveSpeed) {
			_rigidBody.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * _accelaration);
		}

		Camera cam = Camera.main;
		float camDis = cam.transform.position.y - transform.position.y;
		Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));
		float angleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
		float angle = angleRad * Mathf.Rad2Deg;
		_rigidBody.rotation = angle;
		//transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
	}
}
