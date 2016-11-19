using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SuckDust : MonoBehaviour {
	[SerializeField]
	private float _centerSuckForce;

	private List<GameObject> _suckableDust;

	private CircleCollider2D _collider;

	private void Awake () {
		_suckableDust = new List<GameObject>();
	}

	private void Start () {
		_collider = GetComponent<CircleCollider2D>();
	}

	private void Update () {
		if (Input.GetMouseButton(0)) {
			//TODO Scale suckforce with distance

			foreach (GameObject dust in _suckableDust) {
				//TODO This is super hacky (sometimes dust can be null after beeing destroyed [not removed from list])
				if (dust != null) {
					//TODO make this multiple lines jo
					// * Remap(distance, 0.0f, colliderradius + other collider radius, 0.0f, 1.0f)
					//dust.GetComponent<Rigidbody2D>().AddForce((transform.position - dust.transform.position).normalized * Mathf.Max(Vector3.Dot(transform.right, (dust.transform.position - transform.position).normalized), 0.0f) * _centerSuckForce * ExtensionMethods.Remap(Vector3.Distance(dust.transform.position, transform.position), 0.0f, ));
					Vector3 suckPosToDustPos = dust.transform.position - transform.position;
					float dotProduct = Mathf.Max(Vector3.Dot(transform.right, suckPosToDustPos.normalized), 0.0f);
					float distanceFalloff = Mathf.Max(ExtensionMethods.Remap(suckPosToDustPos.magnitude, 0.0f, _collider.radius, 1.0f, 0.0f), 0.0f);
					dust.GetComponent<Rigidbody2D>().AddForce(-suckPosToDustPos.normalized * dotProduct * distanceFalloff * _centerSuckForce);
				}
			}
		}
	}

	private void OnTriggerEnter2D (Collider2D pOther) {
		if (pOther.tag == "Dust") {
			_suckableDust.Add(pOther.gameObject);
		}
		
	}

	private void OnTriggerExit2D (Collider2D pOther) {
		if (pOther.tag == "Dust") {
			_suckableDust.Remove(pOther.gameObject);
		}
	}

	public void RemoveDust (GameObject pDust) {
		_suckableDust.Remove(pDust);
	}
}
