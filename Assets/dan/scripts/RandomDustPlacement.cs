﻿using UnityEngine;
using System.Collections;

public class RandomDustPlacement : MonoBehaviour {
	[SerializeField]
	private GameObject _dustPrefab;

	[SerializeField]
	private float _placeRadius;

	[SerializeField]
	private int _dustCount;

	private void Awake () {
		for (int i = 0; i < _dustCount; ++i) {
			Vector2 randomPos = Random.insideUnitCircle * Random.Range(0.0f, _placeRadius);
			Instantiate(_dustPrefab, new Vector3(randomPos.x, randomPos.y, 0.0f), Quaternion.identity, transform);
		}
	}
}