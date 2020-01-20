using UnityEngine;
using System.Collections;

public class SuckSounds : MonoBehaviour
{
	[SerializeField]
	private float _pitchRange;

	private AudioSource _audioSource;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
		_audioSource.clip = Resources.Load<AudioClip>("sounds/vacuum_suck");

	}

	public void SuckIn()
	{
		if (!_audioSource.isPlaying)
		{
			_audioSource.pitch = Random.Range(1.0f - _pitchRange, 1.0f + _pitchRange);
			_audioSource.Play();
		}
	}
}
