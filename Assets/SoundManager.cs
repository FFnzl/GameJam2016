using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {
	[SerializeField]
	AudioMixer _mixer;

	float musicVolume;
	float effectVolume;

	public bool EffectsOn () {
		float value;
		_mixer.GetFloat("EffectVolume", out value);
		return value > -70.0f;
	}

	public bool MusicOn () {
		float value;
		_mixer.GetFloat("MusicVolume", out value);
		return value > -70.0f;
	}

	public void ToggleMusic () {
		float value;
		_mixer.GetFloat("MusicVolume", out value);

		if (value > -70.0f) {
			musicVolume = value;
			_mixer.SetFloat("MusicVolume", -80.0f);
		} else {
			_mixer.SetFloat("MusicVolume", musicVolume);
		}
	}

	public void ToggleEffects () {
		float value;
		Debug.Log(_mixer.GetFloat("EffectVolume", out value));

		if (value > -70.0f) {
			effectVolume = value;
			_mixer.SetFloat("EffectVolume", -80.0f);
		} else {
			_mixer.SetFloat("EffectVolume", effectVolume);
		}
	}
}
