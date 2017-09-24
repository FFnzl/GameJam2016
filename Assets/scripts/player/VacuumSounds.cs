using UnityEngine;
using System.Collections;

public class VacuumSounds : MonoBehaviour {
	private Plug _plug;
	private AudioSource _audioSource;

	private AudioClip _startClip;
	private AudioClip _loopClip;
	private AudioClip _stopClip;

	private void Awake () {
		_startClip = Resources.Load<AudioClip>("sounds/effects/sfx_vacuum_start");
		_loopClip = Resources.Load<AudioClip>("sounds/effects/sfx_vacuum_loop");
		_stopClip = Resources.Load<AudioClip>("sounds/effects/sfx_vacuum_stop");
	}

	private void Start () {
		_audioSource = GetComponent<AudioSource>();
		_plug = FindObjectOfType<Plug>();
	}

	public void ConnectedPlug () {
		_audioSource.loop = false;
		_audioSource.clip = _startClip;
		_audioSource.Play();
	}

	public void DisconnectedPlug () {
		_audioSource.loop = false;
		_audioSource.clip = _stopClip;
		_audioSource.Play();
	}

	private void Update () {
		if (!_audioSource.isPlaying && _plug.Connected) {
			_audioSource.clip = _loopClip;
			_audioSource.loop = true;
			_audioSource.Play();
		}
	}
}
