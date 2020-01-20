using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageColorSwitch : ColorChanger
{
	private Image _image;

	protected void Start()
	{
		_image = GetComponent<Image>();
		ColorGetter = () => _image.color;
		ColorSetter = x => _image.color = x;
	}
}
