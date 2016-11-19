using UnityEngine;
using System.Collections;

public class DestroyDust : MonoBehaviour {
	private SuckDust _suckDust;

	private void Start () {
		_suckDust = FindObjectOfType<SuckDust>();
	}

	private void OnTriggerStay2D (Collider2D pOther) {
		if (pOther.tag == "Dust" && Input.GetMouseButton(0)) {
			//TODO Scale tween
			Destroy(pOther.gameObject);
		}
	}
}
