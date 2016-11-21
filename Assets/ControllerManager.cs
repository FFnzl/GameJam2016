using UnityEngine;
using System.Collections;

public class ControllerManager : MonoBehaviour {
	public bool UsingController = false;

	private void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	public void ToggleSetting () {
		UsingController = !UsingController;
	}
}
