using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class UITimeBehaviour : MonoBehaviour
{

	private Text _txt;

	[SerializeField]
	private float _timeLimit;

	private ChatBehaviour _chat;

	private Color _startColor;
	private int _startSize;
	private bool _isChanging;
	private Stats _stats;

	// Use this for initialization
	void Start()
	{
		_txt = GetComponent<Text>();
		_startColor = _txt.color;
		_startSize = _txt.fontSize;
		_stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
		_chat = GameObject.FindGameObjectWithTag("Chat").GetComponent<ChatBehaviour>();
	}

	// Update is called once per frame
	void Update()
	{
		_timeLimit -= Time.deltaTime;
		_txt.text = ((int)_timeLimit).ToString();
		if (_timeLimit <= 20)
		{
			if (_timeLimit <= 10) ShowWarning(0.25f);
			else ShowWarning(0.5f);
		}
		else
		{
			_txt.color = _startColor;
			_txt.fontSize = _startSize;
		}
		_stats.RemainingTime = (int)Mathf.Max(0, _timeLimit);

		if (_timeLimit < 0)
		{
			//TODO Put this somewhere else yo
			SceneManager.LoadScene("scn_gameover");
		}
		if (_timeLimit % 10 <= 1)
		{
			_chat.PopUp(3);
		}
	}

	public void AddPunish(int n)
	{
		_timeLimit -= n;
	}

	private void ShowWarning(float d)
	{
		if (!_isChanging)
		{
			_isChanging = true;
			DOTween.To(() => _txt.color, x => _txt.color = x, Color.red, d).OnComplete(() =>
				 DOTween.To(() => _txt.color, x => _txt.color = x, Color.black, d));
			DOTween.To(() => _txt.fontSize, x => _txt.fontSize = x, _startSize * 2, d).OnComplete(() =>
				 DOTween.To(() => _txt.fontSize, x => _txt.fontSize = x, _startSize, d).OnComplete(() => _isChanging = false));
		}
	}
}
