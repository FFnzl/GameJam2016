using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class Stats : MonoBehaviour
{

	public int ClearedPerfect { get; set; }
	public int Cleared { get; set; }
	public int RoomsTotal { get; set; }
	public int RemainingTime { get; set; }
	public int JunkCollected { get; set; }

	private bool _isDone = false;

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		if (Cleared == RoomsTotal && !_isDone)
		{
			_isDone = true;
			SceneManager.LoadScene("scn_gameover");
		}
	} 

}
