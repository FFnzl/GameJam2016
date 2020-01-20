using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour
{
	[SerializeField]
	private float _footStepDelay;

	[SerializeField]
	private float _pitchRange;

	[SerializeField]
	private float _minVelocity;

	private AudioSource _audioSource;

	private Rigidbody2D _rigidBody;

	private float _timer;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
		_audioSource.clip = Resources.Load<AudioClip>("sounds/footstep");
		_rigidBody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (_rigidBody.velocity.magnitude >= _minVelocity && _timer - Time.time <= 0.0f)
		{
			_audioSource.pitch = Random.Range(1.0f - _pitchRange, 1.0f + _pitchRange);
			_audioSource.Play();
			_timer = Time.time + _footStepDelay;
		}
	}
}
