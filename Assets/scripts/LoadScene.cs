using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	[SerializeField]
	private string _sceneName;

	public void OnClick() {
		SceneManager.LoadScene(_sceneName);
	}
}
