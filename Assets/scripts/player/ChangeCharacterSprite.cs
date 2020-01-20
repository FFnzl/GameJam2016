using UnityEngine;
using System.Collections;

public class ChangeCharacterSprite : MonoBehaviour
{
	[SerializeField]
	private Sprite _normalSprite;

	[SerializeField]
	private Sprite _carrySprite;

	private SpriteRenderer _renderer;

	private void Start()
	{
		_renderer = GetComponent<SpriteRenderer>();
	}

	public void PickUp()
	{
		_renderer.sprite = _carrySprite;
	}

	public void Drop()
	{
		_renderer.sprite = _normalSprite;
	}
}
