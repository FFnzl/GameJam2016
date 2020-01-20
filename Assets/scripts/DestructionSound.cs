using UnityEngine;
using System.Collections;

public class DestructionSound : MonoBehaviour
{
	private AudioSource _source;

	private void Start()
	{
		_source = GetComponent<AudioSource>();
		StartCoroutine(Wait());
	}

	private IEnumerator Wait()
	{
		yield return new WaitWhile(() => _source.isPlaying);
		Destroy(gameObject);
	}
}
