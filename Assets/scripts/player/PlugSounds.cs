using UnityEngine;
using System.Collections;

public class PlugSounds : MonoBehaviour
{
	private AudioSource _audioSource;

	private AudioClip _plugSound;
	private AudioClip _unplugSound;
	private AudioClip _pickupSound;
	private AudioClip _dropSound;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();

		_plugSound = Resources.Load<AudioClip>("sounds/vacuum_plug");
		_unplugSound = Resources.Load<AudioClip>("sounds/vacuum_unplug");
		_pickupSound = Resources.Load<AudioClip>("sounds/plug_pickup");
		_dropSound = Resources.Load<AudioClip>("sounds/plug_drop");
	}

	public void Drop()
	{
		_audioSource.clip = _dropSound;
		_audioSource.Play();
	}

	public void PickUp()
	{
		_audioSource.clip = _pickupSound;
		_audioSource.Play();
	}

	public void Connect()
	{
		_audioSource.clip = _plugSound;
		_audioSource.Play();
	}

	public void Disconnect()
	{
		_audioSource.clip = _unplugSound;
		_audioSource.Play();
	}
}
