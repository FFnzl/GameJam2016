using UnityEngine;
using System.Collections;

public class ParticleSelfDestruct : MonoBehaviour
{
	private ParticleSystem _particles;

	private void Start()
	{
		_particles = GetComponent<ParticleSystem>();
		StartCoroutine(Destroy());
	}

	private IEnumerator Destroy()
	{
		yield return new WaitForSeconds(_particles.main.duration);
		Destroy(gameObject);
	}
}
