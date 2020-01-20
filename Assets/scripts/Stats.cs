using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class Stats : MonoBehaviour
{

	public int ClearedPerfect { get; set; } = -1;
	public int Cleared { get; set; } = -1;
	public int RoomsTotal { get; set; } = -1;
	public int RemainingTime { get; set; } = 9000;
	public int JunkCollected { get; set; } = -1;

	private bool _isDone = false;

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		if (RoomsTotal > 0 && Cleared == RoomsTotal && !_isDone)
		{
			_isDone = true;
			SceneManager.LoadScene("scn_gameover");
		}
	} 

}
