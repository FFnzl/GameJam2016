using UnityEngine;
using System.Collections;

public class RandomRubble : MonoBehaviour {
	[SerializeField]
	private Sprite[] _spriteSheet;

	private void Start () {
		Sprite s = _spriteSheet [Random.Range (0, _spriteSheet.Length)];
		foreach( SpriteRenderer r in GetComponentsInChildren<SpriteRenderer>()) {
			r.sprite = s;
		}
	}
}
