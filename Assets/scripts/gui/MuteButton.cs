using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MuteButton : MonoBehaviour
{
	[SerializeField]
	private AudioMixer _mixer;

	[SerializeField]
	private string _volumeParameter;

	private void Start()
	{
		transform.GetChild(0).gameObject.SetActive(!GroupOn());
	}

	public void OnClick()
	{
		ToggleGroup();
		transform.GetChild(0).gameObject.SetActive(!GroupOn());
	}

	private bool GroupOn()
	{
		_mixer.GetFloat(_volumeParameter, out float value);
		return value > -70.0f;
	}

	private void ToggleGroup()
	{
		_mixer.GetFloat(_volumeParameter, out float value);

		if (value > -70.0f)
		{
			_mixer.SetFloat(_volumeParameter, -80.0f);
		}
		else
		{
			_mixer.SetFloat(_volumeParameter, 0.0f);
		}
	}
}
