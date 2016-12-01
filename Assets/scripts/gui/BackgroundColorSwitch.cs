using UnityEngine;
using System.Collections;

public class BackgroundColorSwitch : ColorSwitch {
	private Camera _camera;

	protected override void Start() {
		base.Start();

		_camera = GetComponent<Camera>();
	}

	private void Update() {
		_camera.backgroundColor = _currentColor;
	}
}
