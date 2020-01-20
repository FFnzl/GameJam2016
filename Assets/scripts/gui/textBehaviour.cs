using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class TextBehaviour : ColorChanger
{

	private Text _txt;

	protected void Start()
	{
		_txt = GetComponent<Text>();
		ColorGetter = () => _txt.color;
		ColorSetter = x => _txt.color = x;
	}
}
