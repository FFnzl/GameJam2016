using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
	private AudioSource _source;

	[SerializeField]
	private AudioClip _menuStart;

	[SerializeField]
	private AudioClip _menuLoop;

	[SerializeField]
	private AudioClip _gameLoop;

	Coroutine _waitRoutine;

	private void Awake () {
		DontDestroyOnLoad(gameObject);

		_source = GetComponent<AudioSource>();
	}

	private void Start () {
		if (FindObjectsOfType<MusicManager>().Length > 1) {
			Destroy(gameObject);
		}
	}

	private string _lastScene = "";
	private bool _firstTime = true;

	//TODO Make this without strings!
	private void LoadedLevel (Scene scene, LoadSceneMode mode) {
		if (scene.name == "scn_menu" && _lastScene != "scn_credits" && _lastScene != "scn_gameover") {
			_source.loop = false;
			_source.clip = _menuStart;
			_source.Play();
			_waitRoutine = StartCoroutine(waitForFinish(_menuLoop, true));
		} else if (scene.name == "scn_level" && _firstTime) {
			_firstTime = false;
			_source.loop = false;
			StopCoroutine(_waitRoutine);
			_waitRoutine = StartCoroutine(waitForFinish(_gameLoop, true));
		}

		_lastScene = scene.name;
	}

	private IEnumerator waitForFinish (AudioClip pNextClip, bool pLoop) {
		yield return new WaitWhile(() => _source.isPlaying);
		_source.loop = pLoop;
		_source.clip = pNextClip;
		_source.Play();
	}

	void OnEnable () {
		SceneManager.sceneLoaded += LoadedLevel;
	}

	void OnDisable () {
		SceneManager.sceneLoaded -= LoadedLevel;
	}
}
