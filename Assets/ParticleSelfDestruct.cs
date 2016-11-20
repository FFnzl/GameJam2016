using UnityEngine;
using System.Collections;

public class ParticleSelfDestruct : MonoBehaviour {
	private ParticleSystem _particles;

	private void Start () {
		_particles = GetComponent<ParticleSystem>();
		StartCoroutine(destroy());
	}

	private IEnumerator destroy () {
		yield return new WaitForSeconds(_particles.duration);
		Destroy(gameObject);
	}
}
