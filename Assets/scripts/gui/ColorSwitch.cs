using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ColorSwitch : MonoBehaviour {
	[SerializeField]
	private Color[] _colors = {
		new Color(0.7f, 0, 0.7f), new Color(0, 0, 0.7f),
		new Color(0, 0.7f, 0.7f), new Color(0, 0.7f, 0),
		new Color(0.7f, 0.7f, 0), new Color(0.7f, 0, 0)
	};

	[SerializeField]
	public float _duration;

	protected Color _currentColor;

	private int _colorIndex;

	protected virtual void Start() {
		setTween();
	}

	private void changeColor() {
		_colorIndex = ++_colorIndex % _colors.Length;
		setTween();
	}

	private void setTween() {
		DOTween.To(() => _currentColor, x => _currentColor = x, _colors[_colorIndex], _duration).OnStepComplete(() => changeColor());
	}
}
