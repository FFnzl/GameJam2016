using UnityEngine;
using System.Collections;

public class Sparkling : MonoBehaviour {
	private ParticleSystem[] _particles;

	private void Start () {

	}

	public void PlaySparkle (Vector3 pWorldPos) {
		transform.position = pWorldPos;

		foreach (ParticleSystem ps in _particles) {

		}
	}
}
