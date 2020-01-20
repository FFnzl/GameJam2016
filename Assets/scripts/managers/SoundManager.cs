using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
	[SerializeField]
	AudioMixer _mixer;

	private float _musicVolume;
	private float _effectVolume;

	private void Start()
	{
		if (FindObjectsOfType<SoundManager>().Length > 1)
		{
			Destroy(gameObject);
		}
	}

	public bool MusicOn()
	{
		_mixer.GetFloat("MusicVolume", out float value);
		return value > -70.0f;
	}

	public void ToggleMusic()
	{
		_mixer.GetFloat("MusicVolume", out float value);

		if (value > -70.0f)
		{
			_musicVolume = value;
			_mixer.SetFloat("MusicVolume", -80.0f);
		}
		else
		{
			_mixer.SetFloat("MusicVolume", _musicVolume);
		}
	}

	public void ToggleEffects()
	{
		_mixer.GetFloat("EffectVolume", out float value);

		if (value > -70.0f)
		{
			_effectVolume = value;
			_mixer.SetFloat("EffectVolume", -80.0f);
		}
		else
		{
			_mixer.SetFloat("EffectVolume", _effectVolume);
		}
	}
}
