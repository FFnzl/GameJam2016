using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButtonBehaviour : ColorChanger
{

	private Image _image;

	protected void Start()
	{
		_image = GetComponent<Image>();
		ColorGetter = () => _image.color;
		ColorSetter = x => _image.color = x;
	}

	public void GoBack()
	{
		SceneManager.LoadScene("scn_menu");
	}
}
