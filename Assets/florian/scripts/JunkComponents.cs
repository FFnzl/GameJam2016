using UnityEngine;
using System.Collections.Generic;

public class JunkComponents : MonoBehaviour {

    public Sprite[] junk;

    public Sprite RandomJunk
    {
        get { return junk.Length > 0 ? junk[Random.Range(0, junk.Length)] : null; }
    }

}
