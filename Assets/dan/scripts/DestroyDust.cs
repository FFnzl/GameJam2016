using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DestroyDust : MonoBehaviour {
	private Plug _plug;

	private void Start () {
		_plug = FindObjectOfType<Plug>();
	}

	private void OnTriggerStay2D (Collider2D pOther) {
		if (pOther.tag == "Dust" && _plug.Connected) {
			pOther.transform.DOScale(0.0f, 0.3f).OnComplete(() => Destroy(pOther.gameObject));
		}
	}
}
