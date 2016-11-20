using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITimeBehaviour : MonoBehaviour {

    private Text txt;
    [SerializeField] private float timeLimit;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timeLimit -= Time.deltaTime;
        txt.text = ((int)timeLimit).ToString();
	}

    public void addPunish(int n)
    {
        timeLimit -= n;
    }
}
