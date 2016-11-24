using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(FurnitureHelper))]
public class FurnitureHelper_Inspector : Editor {
	private FurnitureHelper _helper;
	private Object _cachedPrefabInstance;

	public void OnEnable () {
		_helper = (FurnitureHelper)target;
		_cachedPrefabInstance = PrefabUtility.GetPrefabParent(_helper.gameObject);

		if (_cachedPrefabInstance != null) {
			PrefabUtility.DisconnectPrefabInstance(_helper.gameObject);
		}
	}

	public override void OnInspectorGUI () {
		DrawDefaultInspector();

		_helper = (FurnitureHelper)target;

		Debug.Log(_helper.FurniturePrefabs.Length);

		foreach (FurnitureHelper.FurnitureData t in _helper.FurniturePrefabs) {
			GUILayout.Label(t.Prefab.name + " Pos: " + t.Position + " Rot: " + t.Rotation.eulerAngles);
		}

		if (GUILayout.Button("Save Room")) {
			if (_cachedPrefabInstance != null) {
				saveFurniturePrefabs();
				PrefabUtility.ReplacePrefab(_helper.gameObject, _cachedPrefabInstance, ReplacePrefabOptions.Default);
				PrefabUtility.DisconnectPrefabInstance(_helper.gameObject);
				DestroyImmediate(_helper.gameObject);
			} else {
				Debug.LogError("You should create a prefab first, otherwise nothin is saved.");
			}
		} else if (GUILayout.Button("Load Furniture")) {
			loadFurniturePrefabs();
		} else if (GUILayout.Button("Clear Saved Furniture")) {
			_helper.ClearFurniture();
		}
	}

	private void saveFurniturePrefabs () {
		_helper.ClearFurniture();

		foreach (Transform t in _helper.PrefabsContainer.transform) {
			if (t.gameObject != _helper.PrefabsContainer && PrefabUtility.GetPrefabParent(t.gameObject) != null) {
				_helper.AddFurniture(new FurnitureHelper.FurnitureData(PrefabUtility.GetPrefabParent(t.gameObject), t.localPosition, t.localRotation));
			}
		}

		clearFurnitureContainer();

		EditorUtility.SetDirty(_helper);
	}

	private void loadFurniturePrefabs () {
		clearFurnitureContainer();

		foreach (FurnitureHelper.FurnitureData t in _helper.FurniturePrefabs) {
			GameObject go = PrefabUtility.InstantiatePrefab(t.Prefab) as GameObject;
			go.transform.parent = _helper.PrefabsContainer.transform;
			go.transform.localPosition = t.Position;
			go.transform.localRotation = t.Rotation;
		}
	}

	private void clearFurnitureContainer () {
		Debug.Log(_helper.PrefabsContainer.transform.childCount);
		List<GameObject> destroyList = new List<GameObject>();

		foreach (Transform t in _helper.PrefabsContainer.transform) {
			if (t.gameObject != _helper.PrefabsContainer && PrefabUtility.GetPrefabParent(t.gameObject) != null) {
				destroyList.Add(t.gameObject);
			}
		}

		foreach (GameObject g in destroyList) {
			DestroyImmediate(g);
		}
	}
}
