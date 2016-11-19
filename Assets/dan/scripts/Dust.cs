using UnityEngine;
using System.Collections;

public class Dust : MonoBehaviour {
	private SuckDust _suckDust;

	private void Start () {
		_suckDust = FindObjectOfType<SuckDust>();
	}

	private void OnDestroy () {
		_suckDust.RemoveDust(gameObject);
	}
}
