using UnityEngine;
using System.Collections;

public class DestructionSound : MonoBehaviour {
	private AudioSource _source;

	private void Start () {
		_source = GetComponent<AudioSource>();
		StartCoroutine(wait());
	}

	private IEnumerator wait () {
		yield return new WaitWhile(() => _source.isPlaying);
		Destroy(gameObject);
	}
}
