using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextColorSwitch : ColorSwitch {
	private Text _text;

	protected override void Start() {
		base.Start();

		_text = GetComponent<Text>();
	}

	private void Update () {
		_text.color = _currentColor;
	}
}
