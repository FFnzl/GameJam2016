using UnityEngine;
using System.Collections;

public class Socket : MonoBehaviour {
	[SerializeField]
	private float _plugOffset = -0.095f;

	[SerializeField]
	private float _breakForce;

	private Transform _plugPosition;

	private FixedJoint2D _joint;

	private void Start () {
		_plugPosition = transform.GetChild(0);
	}

	public void ConnectPlug (Plug pPlug) {
		if (_joint == null) {
			pPlug.Body.position = _plugPosition.position;
			pPlug.Body.rotation = _plugPosition.rotation.z;

			_joint = gameObject.AddComponent<FixedJoint2D>();
			_joint.autoConfigureConnectedAnchor = true;
			_joint.anchor = new Vector2(_plugOffset, 0.0f);
			_joint.connectedBody = pPlug.Body;
			_joint.breakForce = _breakForce;
			_joint.enabled = true;
		}
	}

	public void OnJointBreak2D (Joint2D pBrokenJoint) {
		FindObjectOfType<Plug>().Disconnect();
	}

	public void Disconnect () {
		OnJointBreak2D(_joint);
		Destroy(_joint);
	}
}
