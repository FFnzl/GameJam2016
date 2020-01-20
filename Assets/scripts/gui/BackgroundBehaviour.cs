using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BackgroundBehaviour : ColorChanger
{

	private Camera _camera;

	void Start()
	{
		_camera = GetComponent<Camera>();
		ColorGetter = () => _camera.backgroundColor;
		ColorSetter = x => _camera.backgroundColor = x;
	}
}
