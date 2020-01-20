using UnityEngine;
using System.Collections;

public class Sparkling : MonoBehaviour
{
	private ParticleSystem _particles;
	private AudioSource _source;

	private void Start()
	{
		_particles = GetComponent<ParticleSystem>();
		_source = GetComponent<AudioSource>();
	}

	public void PlaySparkle(Vector3 pWorldPos, float pSize)
	{
		transform.position = pWorldPos;
		ParticleSystem.ShapeModule sm = _particles.shape;
		sm.scale = new Vector3(pSize, pSize, 0.0f);
		_source.Play();
		_particles.Play();
	}
}
