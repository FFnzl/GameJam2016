using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class FurnitureHelper : MonoBehaviour
{
	[Serializable]
	public struct FurnitureData
	{
		public FurnitureData(UnityEngine.Object pPrefab, Vector3 pPos, Quaternion pRot) { Prefab = pPrefab; Position = pPos; Rotation = pRot; }
		public UnityEngine.Object Prefab;
		public Vector3 Position;
		public Quaternion Rotation;
	}

	[SerializeField]
	private GameObject _prefabsContainer;
	public GameObject PrefabsContainer { get { return _prefabsContainer; } }

	[SerializeField]
	private FurnitureData[] _furniturePrefabs = new FurnitureData[0];
	public FurnitureData[] FurniturePrefabs { get { return _furniturePrefabs; } }

	public void AddFurniture(FurnitureData pData)
	{
		FurnitureData[] temp = _furniturePrefabs;
		_furniturePrefabs = new FurnitureData[temp.Length + 1];

		for (int i = 0; i < temp.Length; ++i)
		{
			_furniturePrefabs[i] = temp[i];
		}

		_furniturePrefabs[temp.Length] = pData;
	}

	public void ClearFurniture()
	{
		_furniturePrefabs = new FurnitureData[0];
	}

	private void Awake()
	{
		foreach (FurnitureData fd in _furniturePrefabs)
		{
			GameObject.Instantiate(fd.Prefab, fd.Position, fd.Rotation, _prefabsContainer.transform);
		}
	}
}
