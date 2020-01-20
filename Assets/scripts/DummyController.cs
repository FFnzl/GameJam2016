using UnityEngine;
using System.Collections;

public class DummyController : MonoBehaviour
{

	private Rigidbody2D body;

	[SerializeField]
	private float _movementSpeed;

	// Use this for initialization
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{

		float moveX = Input.GetAxis("Horizontal");
		float moveY = Input.GetAxis("Vertical");
		body.velocity = new Vector2(moveX * _movementSpeed, moveY * _movementSpeed);

	}
}
