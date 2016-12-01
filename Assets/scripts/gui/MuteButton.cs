using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MuteButton : MonoBehaviour {
	[SerializeField]
	private AudioMixer _mixer;

	[SerializeField]
	private string _volumeParameter;

	private void Start() {
		transform.GetChild(0).gameObject.SetActive(!groupOn());
	}

	public void OnClick() {
		toggleGroup();
		transform.GetChild(0).gameObject.SetActive(!groupOn());
	}

	private bool groupOn() {
		float value;
		_mixer.GetFloat(_volumeParameter, out value);
		return value > -70.0f;
	}

	private void toggleGroup() {
		float value;
		_mixer.GetFloat(_volumeParameter, out value);

		if (value > -70.0f) {
			_mixer.SetFloat(_volumeParameter, -80.0f);
		} else {
			_mixer.SetFloat(_volumeParameter, 0.0f);
		}
	}
}
