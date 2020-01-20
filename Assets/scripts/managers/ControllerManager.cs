using UnityEngine;
using System.Collections;

public class ControllerManager : MonoBehaviour
{
	public bool IsUsingController = false;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
		if (FindObjectsOfType<MusicManager>().Length > 1)
		{
			Destroy(gameObject);
		}
	}

	public void ToggleSetting()
	{
		IsUsingController = !IsUsingController;
	}
}
