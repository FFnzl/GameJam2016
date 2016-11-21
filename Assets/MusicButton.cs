using UnityEngine;
using System.Collections;

public class MusicButton : MonoBehaviour {
	void Start () {
		transform.GetChild(0).gameObject.SetActive(!FindObjectOfType<SoundManager>().MusicOn());
	}

	public void OnClick () {
		transform.GetChild(0).gameObject.SetActive(!FindObjectOfType<SoundManager>().MusicOn());
	}
}
