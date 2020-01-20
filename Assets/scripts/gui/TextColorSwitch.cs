using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextColorSwitch : ColorChanger
{
	private Text _text;

	protected void Start()
	{
		_text = GetComponent<Text>();
		ColorGetter = () => _text.color;
		ColorSetter = x => _text.color = x;
	}

}
