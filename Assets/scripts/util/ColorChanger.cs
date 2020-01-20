using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public abstract class ColorChanger : MonoBehaviour
{

	public Color[] Colors { get; set; } =
	{
		new Color(0.7f, 0, 0.7f), new Color(0, 0, 0.7f),
		new Color(0, 0.7f, 0.7f), new Color(0, 0.7f, 0),
		new Color(0.7f, 0.7f, 0), new Color(0.7f, 0, 0)
	};
	public bool IsTweening { get; private set; }

	[SerializeField]
	private float _duration;

	protected DG.Tweening.Core.DOGetter<Color> ColorGetter { get; set; }
	protected DG.Tweening.Core.DOSetter<Color> ColorSetter { get; set; }

	private int _colorIncrease;

	protected void Update()
	{
		if (!IsTweening) ChangeColor();
	}

	private void ChangeColor()
	{
		IsTweening = true;
		DOTween.To(ColorGetter, ColorSetter, Colors[_colorIncrease], _duration).OnComplete(() => IsTweening = false);
		_colorIncrease = ++_colorIncrease % Colors.Length;
	}
}

