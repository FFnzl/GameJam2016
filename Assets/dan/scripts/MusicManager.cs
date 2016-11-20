using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
	private AudioSource _source;

	private AudioClip _menuStart;
	private AudioClip _menuLoop;
	private AudioClip _gameLoop;

	Coroutine _waitRoutine;

	private void Awake () {
		DontDestroyOnLoad(gameObject);

		_source = GetComponent<AudioSource>();

		_menuStart = Resources.Load<AudioClip>("sounds/maintheme_menu_start");
		_menuLoop = Resources.Load<AudioClip>("sounds/maintheme_menu_loop");
		_gameLoop = Resources.Load<AudioClip>("sounds/maintheme_game_loop");
	}

	private void Start () {
		if (FindObjectsOfType<MusicManager>().Length > 1) {
			Destroy(gameObject);
		}
	}

	private string _lastScene = "";

	private void LoadedLevel (Scene scene, LoadSceneMode mode) {
		if (scene.name == "MenuScene" && _lastScene != "CreditsScene") {
			_source.loop = false;
			_source.clip = _menuStart;
			_source.Play();
			_waitRoutine = StartCoroutine(waitForFinish(_menuLoop, true));
		} else if (scene.name == "MainScene") {
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
