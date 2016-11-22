using UnityEngine;
using System.Collections;

public class RandomDustPlacement : MonoBehaviour {
	[SerializeField]
	private GameObject _dustPrefab;

	[SerializeField]
	private float _placeRadius;

	[SerializeField]
	private int _dustCount;

    private Room room;

	/*
    private void Start () {
        room = GetComponent<Room>();

        for (int i = 0; i < _dustCount; ++i) {
			Vector2 randomPos = Random.insideUnitCircle * Random.Range(0.0f, _placeRadius);
			GameObject o = (Instantiate(_dustPrefab, new Vector3(randomPos.x, randomPos.y, 0.0f), Quaternion.Euler(0,0,Random.Range(0f, 360f)), transform) as GameObject);
            o.transform.localPosition = new Vector3(randomPos.x, randomPos.y, 0.0f);
            o.GetComponent<SpriteRenderer>().sprite = GameObject.FindGameObjectWithTag("JunkManager").GetComponent<JunkComponents>().RandomJunk;
            /*if (room != null)*//* room.dust.Add(o);
        }

		Debug.Log("Room Dust " + _dustCount);
	}
	*/

	public void GenerateDust () {
		if (isActiveAndEnabled) {
			room = GetComponent<Room>();

			for (int i = 0; i < _dustCount; ++i) {
				Vector2 randomPos = Random.insideUnitCircle * Random.Range(0.0f, _placeRadius);
				GameObject o = (Instantiate(_dustPrefab, new Vector3(randomPos.x, randomPos.y, 0.0f), Quaternion.Euler(0, 0, Random.Range(0f, 360f)), transform) as GameObject);
				o.transform.localPosition = new Vector3(randomPos.x, randomPos.y, 0.0f);
				o.GetComponent<SpriteRenderer>().sprite = GameObject.FindGameObjectWithTag("JunkManager").GetComponent<JunkComponents>().RandomJunk;
				/*if (room != null)*/
				room.dust.Add(o);
			}
		}

	}
}
