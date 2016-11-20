using UnityEngine;
using System.Collections;

public class RandomRubble : MonoBehaviour {
	[SerializeField]
	private Sprite[] _spriteSheet;

	private void Start () {
		GetComponent<SpriteRenderer>().sprite = _spriteSheet[Random.Range(0, _spriteSheet.Length)];
	}
}
