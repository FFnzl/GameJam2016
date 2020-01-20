using UnityEngine;
using System.Collections;

public class BackgroundColorSwitch : ColorChanger
{
	private Camera _camera;

	void Start()
	{
		_camera = GetComponent<Camera>();
		ColorGetter = () => _camera.backgroundColor;
		ColorSetter = x => _camera.backgroundColor = x;
	}
}
