using UnityEngine;
using System.Collections;

public class ControllerButton : MonoBehaviour {
	void Start () {
		transform.GetChild(0).gameObject.SetActive(!PlayerPrefsX.GetBool("controller", false));
	}

	public void OnClick () {
		PlayerPrefsX.SetBool("controller", !PlayerPrefsX.GetBool("controller"));
		transform.GetChild(0).gameObject.SetActive(!PlayerPrefsX.GetBool("controller"));
	}
}
