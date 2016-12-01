using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageColorSwitch : ColorSwitch {
	private Image _image;

	protected override void Start() {
		base.Start();

		_image = GetComponent<Image>();
	}

	private void Update() {
		_image.color = _currentColor;
	}
}
