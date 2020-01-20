using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ScoreTextBehaviour : MonoBehaviour
{
	private MeshRenderer rend;

	// Use this for initialization
	void Start()
	{
		rend = GetComponent<MeshRenderer>();
		rend.sortingLayerName = "UI";
		rend.sortingOrder = 5;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
