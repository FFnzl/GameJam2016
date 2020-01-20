using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCalculation : MonoBehaviour
{

	[SerializeField]
	private Text _perfectScoreTxt;

	[SerializeField]
	private Text _timeScoreTxt;

	[SerializeField]
	private Text _roomsTxt;

	[SerializeField]
	private Text _endScoreTxt;

	private GameObject _stats;

	private int _perfects;
	private int _clearedRooms;
	private int _totalRooms;
	private int _restTime;
	private int _junk;

	// Use this for initialization
	void Start()
	{
		_stats = GameObject.FindGameObjectWithTag("Stats");
		Stats s = _stats.GetComponent<Stats>();

		_restTime = s.RemainingTime;
		_totalRooms = s.RoomsTotal;
		_clearedRooms = s.Cleared;
		_perfects = s.ClearedPerfect;
		_junk = s.JunkCollected;

		_timeScoreTxt.text = _restTime.ToString();
		_roomsTxt.text = _clearedRooms.ToString() + " of " + _totalRooms.ToString();
		_perfectScoreTxt.text = _perfects.ToString() + " of " + _clearedRooms.ToString();

		_endScoreTxt.text = Calc().ToString();
		Destroy(s.gameObject);
	}

	private int Calc()
	{
		int result;

		result =
			_restTime * 100 +
			_clearedRooms * 1000 +
			_perfects * 1000 +
			_junk * 5;

		if (_totalRooms == _clearedRooms) result += 5000;

		return result;
	}

}
