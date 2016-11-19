using UnityEngine;
using System.Collections;

public class Cable : MonoBehaviour {
	private  DistanceJoint2D _distanceJoint;
	public DistanceJoint2D DistanceJoint { get { return _distanceJoint; } }
	private HingeJoint2D _hingeJoint;
	public HingeJoint2D HingeJoint { get { return _hingeJoint; } }
	private Rigidbody2D _rigidBody;
	public Rigidbody2D RigidBody { get { return _rigidBody; } }

	public Transform UpperConnector;
	public Transform LowerConnector;

	private void Awake () {
		_distanceJoint = GetComponent<DistanceJoint2D>();
		_hingeJoint = GetComponent<HingeJoint2D>();
		_rigidBody = GetComponent<Rigidbody2D>();
	}
}
