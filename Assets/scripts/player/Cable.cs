using UnityEngine;
using System.Collections;

public class Cable : MonoBehaviour
{
	public DistanceJoint2D DistanceJoint { get; private set; }
	public HingeJoint2D HingeJoint { get; private set; }
	public Rigidbody2D RigidBody { get; private set; }

	public Transform UpperConnector;
	public Transform LowerConnector;

	private void Awake()
	{
		DistanceJoint = GetComponent<DistanceJoint2D>();
		HingeJoint = GetComponent<HingeJoint2D>();
		RigidBody = GetComponent<Rigidbody2D>();
	}
}
