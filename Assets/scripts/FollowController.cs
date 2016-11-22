using UnityEngine;
using System.Collections;

public class FollowController : MonoBehaviour {

    public Transform follow;
	
	void Update () {
        transform.position = new Vector3(follow.position.x, follow.position.y, transform.position.z);
    }
}
