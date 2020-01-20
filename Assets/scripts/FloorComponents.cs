using UnityEngine;
using System.Collections;

public class FloorComponents : MonoBehaviour
{

	[SerializeField]
	private string[] _floorPattern;

	[SerializeField]
	private Sprite[] _floors;

	[SerializeField]
	private GameObject _floorPrefab;

	[SerializeField]
	private GameObject _textPrefab;

	public GameObject FloorPrefab => _floorPrefab;
	public GameObject TextPrefab => _textPrefab;
	public Sprite[] Floors => _floors;

	public Sprite RandomSprite
	{
		get { return _floors.Length > 0 ? _floors[Random.Range(0, _floors.Length)] : null; }
	}

	public string RandomPattern
	{
		get { return _floorPattern.Length > 0 ? _floorPattern[Random.Range(0, _floorPattern.Length)] : null; }
	}

}
